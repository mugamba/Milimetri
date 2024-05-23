using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace MilimetriApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonOdaberiFolder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    textBoxFolder.Text = fbd.SelectedPath;
                }
            }

        }

        private void buttonOdaberiDatoteku_Click(object sender, EventArgs e)
        {
            using (var fbd = new OpenFileDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.FileName))
                {
                    textBoxSelectedFile.Text = fbd.FileName;
                }
            }
        }

        private void buttonPokreniObradu_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(textBoxFolder.Text) || !File.Exists(textBoxSelectedFile.Text))
            {
                MessageBox.Show("Odabrana datoteka ili direktorij nisu ispravni!");
            }
            else
            { 
            
                var lines = File.ReadAllLines(textBoxSelectedFile.Text);

                var list = new List<MilimetriData>();
                var provider = new CultureInfo("en-EN");

                foreach (var line in lines)
                {

                    var mili = new MilimetriData();

                   var splits =  line.Split(",");
                   
                    if (!String.IsNullOrEmpty(splits[0]))
                        mili.Atribut1 = decimal.Parse(splits[0], System.Globalization.NumberStyles.AllowDecimalPoint, provider);
                    if (!String.IsNullOrEmpty(splits[1]))
                        mili.Atribut2 = decimal.Parse(splits[1], System.Globalization.NumberStyles.AllowDecimalPoint, provider);
                    if (!String.IsNullOrEmpty(splits[2]))
                        mili.X = decimal.Parse(splits[2], System.Globalization.NumberStyles.AllowDecimalPoint, provider);
                    if (!String.IsNullOrEmpty(splits[3]))
                        mili.Y = decimal.Parse(splits[3], System.Globalization.NumberStyles.AllowDecimalPoint, provider);

                    list.Add(mili);
                }


                var test = list.Count;

                var grouped = list.GroupBy(o => new { o.X, o.Y }).Select(g => g).ToList();


                var returnListMilimeti = new List<MilimetriData>();
                var errorList = new List<MilimetriData>();

                foreach (var group in grouped)
                {
                    var returnData = new MilimetriData();

                    returnData.X = group.Key.X;
                    returnData.Y = group.Key.Y;


                    var listAtt1 = list.Where(o => o.X == group.Key.X && o.Y == group.Key.Y && o.Atribut1 != null).ToList();
                    if (listAtt1.Count > 1)
                        errorList.AddRange(listAtt1);
                    else
                    {
                        if (listAtt1.Count == 1)
                        {
                            returnData.Atribut1 = listAtt1.Select(o => o.Atribut1).FirstOrDefault();
                        }
                    
                    }

                    var listAtt2 = list.Where(o => o.X == group.Key.X && o.Y == group.Key.Y && o.Atribut2 != null).ToList();
                    if (listAtt2.Count > 1)
                        errorList.AddRange(listAtt2);
                    else
                    {
                        if (listAtt1.Count == 1)
                        {
                            returnData.Atribut2 = listAtt2.Select(o => o.Atribut2).FirstOrDefault();
                        }

                    }

                    returnListMilimeti.Add(returnData);
                }


                var builder1 = new StringBuilder();
                foreach (var tt in returnListMilimeti)
                    builder1.AppendLine(String.Format(CultureInfo.InvariantCulture, "{0:######################.######################}," +
                        "{1:######################.######################}," +
                        "{2:######################.######################}," +
                        "{3:######################.######################}", tt.Atribut1, tt.Atribut2, tt.X, tt.Y));


                var builder2 = new StringBuilder();
                foreach (var tt in errorList)
                    builder2.AppendLine(String.Format(CultureInfo.InvariantCulture, "{0:######################.######################}," +
                        "{1:######################.######################}," +
                        "{2:######################.######################}," +
                        "{3:######################.######################}", tt.Atribut1, tt.Atribut2, tt.X, tt.Y));

                FileInfo v = new FileInfo(textBoxSelectedFile.Text);

                File.WriteAllText(textBoxFolder.Text + "\\" + v.Name.Replace(v.Extension, "") + "_Obrada_" + DateTime.Today.ToString("yyyyMMdd")+v.Extension , builder1.ToString());
                
                if (builder2.Length == 0)
                    File.WriteAllText(textBoxFolder.Text + "\\" + v.Name.Replace(v.Extension, "") + "_Log_" + DateTime.Today.ToString("yyyyMMdd") + v.Extension, "Nema neispravnih stavki!" );
                else
                    File.WriteAllText(textBoxFolder.Text + "\\" + v.Name.Replace(v.Extension, "") + "_Log_" + DateTime.Today.ToString("yyyyMMdd") + v.Extension,  builder2.ToString());


                var message = builder2.Length == 0 ? "Uspješno je obrađena datoteka, nije bilo pogrešnih unosa, pogledaj u izlazni direktorij!" :
                    "Ima pogrešnih upisa, pogledaj u izlazni direktorij u Log datoteku.";

                MessageBox.Show(message);
            }
        }
    }

    public class MilimetriData
    { 
        public Decimal X { get; set; }
        public Decimal Y { get; set; }
        public Decimal? Atribut1 { get; set; }
        public Decimal? Atribut2 { get; set; }

    }






}
