using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using ReportGenerationRPA.Models;
using System.Data;
using System.IO;
using System.Xml;

namespace ReportGenerationRPA
{
    public partial class Form1 : Form
    {
        DataTable dataTable;
        private string storageConnectionString = "";
        private string containerName = "fyp";
        private string filePath = @"C:\Users\wasif\Downloads\sema-lmes.xml";
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Show();
            progressBar1.Value = 5;

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please enter a link to download");
                return;
            }

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Please enter a name to search");
                return;
            }

            var name = textBox1.Text.Split('/').Last();

            await Task.Delay(5000);
            var res = await SearchDownloadsFolder(name);
            if (!res)
                await DownloadFile(name);

            await Task.Delay(10000);
            await SearchByName();

            await Task.Delay(7000);
            SaveFileInAzure();

            await Task.Delay(10000);
            GenerateSasUrlForBlob(name);
        }

        private void GenerateSasUrlForBlob(string blobName)
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(storageConnectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = containerClient.GetBlobClient(blobName);
            var uri = blobClient.Uri;
            richTextBox2.Text = uri.OriginalString;
            progressBar1.Value = 100;
            checkBox6.Checked = true;
            //if (!blobClient.Exists())
            //{
            //    throw new Exception("Blob does not exist.");
            //}

            //BlobSasBuilder sasBuilder = new BlobSasBuilder
            //{
            //    BlobContainerName = containerName,
            //    BlobName = blobName,
            //    Resource = "b",
            //    ExpiresOn = DateTimeOffset.UtcNow.AddHours(1) // Set the expiration time as needed
            //};

            //sasBuilder.SetPermissions(BlobSasPermissions.Read);

            //Uri sasUri = blobClient.GenerateSasUri(sasBuilder);
            //return sasUri.ToString();
        }

        private async void SaveFileInAzure()
        {
            // Create a BlobServiceClient object which will be used to create a container client
            BlobServiceClient blobServiceClient = new BlobServiceClient(storageConnectionString);

            // Create the container and return a container client object
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            // Create the container if it does not exist
            await containerClient.CreateIfNotExistsAsync();

            // Get a reference to a blob
            string blobName = Path.GetFileName(filePath);
            BlobClient blobClient = containerClient.GetBlobClient(blobName);

            Console.WriteLine($"Uploading to Blob storage as blob:\n\t {blobClient.Uri}");

            // Open the file and upload its data
            using FileStream uploadFileStream = File.OpenRead(filePath);
            await blobClient.UploadAsync(uploadFileStream, true);
            uploadFileStream.Close();
            progressBar1.Value = 80;
            checkBox4.Checked = true;
        }

        private Task SearchByName()
        {
            try
            {
                var records = new List<FincertRecords>();
                List<DataRow> dataRows = dataTable.AsEnumerable().ToList();
                foreach (var item in dataRows)
                {
                    var model = new FincertRecords
                    {
                        Country = item["Country"].ToString(),
                        LastName = item["LastName"].ToString(),
                        GivenName = item["GivenName"].ToString(),
                        DateOfBirth = item["DateOfBirth"].ToString(),
                        Schedule = item["Schedule"].ToString(),
                        Item = Convert.IsDBNull(item["Item"]) ? null : Convert.ToDouble(item["Item"]),
                        Aliases = item["Aliases"].ToString(),
                        Entity = item["Entity"].ToString(),
                        Title = item["Title"].ToString(),
                    };
                    records.Add(model);
                }

                var tt = records.Where(x => x.GivenName.Contains(textBox2.Text)).FirstOrDefault();
                if (tt != null)
                {
                    richTextBox1.Text = $"{nameof(tt.Entity) + ": " + tt.Entity} \n" +
                        $"{nameof(tt.Country) + ": " + tt.Country} \n" +
                        $"{nameof(tt.Title) + ": " + tt.Title} \n" +
                        $"{nameof(tt.GivenName) + ": " + tt.GivenName} \n" +
                        $"{nameof(tt.LastName) + ": " + tt.LastName} \n" +
                        $"{nameof(tt.Schedule) + ": " + tt.Schedule} \n" +
                        $"{nameof(tt.Aliases) + ": " + tt.Aliases} \n" +
                        $"{nameof(tt.Item) + ": " + tt.Item} \n" +
                        $"{nameof(tt.DateOfBirth) + ": " + tt.DateOfBirth} \n";
                }
                progressBar1.Value = 60;
                checkBox3.Checked = true;
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        private async Task DownloadFile(string fileName)
        {
            try
            {
                using var httpClient = new HttpClient();

                using var response = await httpClient.GetAsync(textBox1.Text);
                if (response.IsSuccessStatusCode)
                {
                    using var stream = await response.Content.ReadAsStreamAsync();

                    byte[] fileBytes = await response.Content.ReadAsByteArrayAsync();

                    string downloadsFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                    string filePath = Path.Combine(downloadsFolderPath, fileName);

                    await File.WriteAllBytesAsync(filePath, fileBytes);

                    dataTable = await ReadFincertXMLDataToDataTable(stream);

                    progressBar1.Value = 40;
                    checkBox2.Checked = true;
                }
                else
                {
                    MessageBox.Show("Issue in downloading the file");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public Task<DataTable> ReadFincertXMLDataToDataTable(Stream XmlFile)
        {
            XmlDocument doc = new XmlDocument();

            doc.Load(XmlFile);

            DataTable dataTable = new DataTable();

            try
            {
                dataTable.TableName = "XMLRecords";
                var NodoEstructura = doc.DocumentElement.ChildNodes.Cast<XmlNode>().ToList();
                foreach (XmlNode columna in NodoEstructura)
                {
                    var child = columna.ChildNodes.Cast<XmlNode>().ToList();
                    foreach (XmlNode columnb in child)
                    {
                        if (dataTable.Columns.Contains(columnb.Name))
                        {
                            var index = dataTable.Columns.IndexOf(columnb.Name);
                            dataTable.Columns.RemoveAt(index);
                            dataTable.Columns.Add(columnb.Name, typeof(String));
                        }
                        if (!dataTable.Columns.Contains(columnb.Name))
                            dataTable.Columns.Add(columnb.Name, typeof(String));
                    }
                }

                XmlNode Filas = doc.DocumentElement;
                foreach (XmlNode Fila in Filas.ChildNodes)
                {
                    var Valores = Fila.ChildNodes.Cast<XmlNode>().ToList();
                    DataRow dataRow = dataTable.NewRow();
                    foreach (var item in Valores)
                    {
                        dataRow[item.Name] = item.InnerText;
                    }
                    dataTable.Rows.Add(dataRow);
                }
                return Task.FromResult(dataTable);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        private async Task<bool> SearchDownloadsFolder(string name)
        {
            // Get the path to the Downloads folder
            string downloadsFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");

            // Specify the file name you are looking for
            string fileNameToSearch = "example.txt"; // Change this to the name of the file you're looking for

            // Get the full path of the file in the Downloads folder
            string filePath = Path.Combine(downloadsFolderPath, name);

            // Check if the file exists
            if (File.Exists(filePath))
            {
                // Open the file as a stream
                using Stream fileStream = File.OpenRead(filePath);

                dataTable = await ReadFincertXMLDataToDataTable(fileStream);

                progressBar1.Value = 20;
                checkBox1.Checked = true;
                return true;
            }
            else
            {
                progressBar1.Value = 20;
                checkBox1.Checked = true;
                return false;
            }
        }
    }
}
