using System;
using System.Collections.Generic;
using System.Windows.Forms;
//using AutocompleteMenuNS;

namespace Tester
{
    public partial class MainForm : Form
    {
        bool BoolTag = false;
        bool RealTag = false;
        bool Tagentering = true;
        bool Modeselect = false;
        bool Statusselect = false;
        int TagType = 0;
        List<string> list = new List<string>();
        public MainForm()
        {
            InitializeComponent();
           
        }

        
        private void button4_Click(object sender, EventArgs e)
        {
           // new CustomItemSample().Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            

            list.Add("bool");
            list.Add("real");
            list.Add("byte");
            list.Add("April");
            list.Add("May");
            list.Add("June");
            list.Add("July");
            list.Add("August");
            list.Add("September");
            list.Add("October");
            list.Add("November");
            list.Add("December");
            //var source = new AutoCompleteStringCollection();
            //source.AddRange(new string[]
            //        {
            //            "bool",
            //            "real",
            //            "March",
            //            "April",
            //            "May",
            //            "June",
            //            "July",
            //            "August",
            //            "September",
            //            "October",
            //            "November",
            //            "December"
            //        });
            //textBox1.AutoCompleteCustomSource = source;
            //textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            autocompleteMenu1.SetAutocompleteItems(list);


           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            string[] words = str.Split('.');
            List<string> tag = new List<string>();
            int len = 0;
            bool hasdot = false;
            len = words.GetLength(0);

            for (int i = 0; i < len; i++)
            {
                if (words[i] != "")
                {
                    tag.Add(words[i]);
                }
                else
                {
                    hasdot = true;
                }
            }
            len = tag.Count;

            if (len == 0)
            {
                autocompleteMenu1.SetAutocompleteItems(list);
            }
            else
            {
                if ((len == 1) && hasdot)
                {
                    //autocompleteMenu1.SetAutocompleteItems(list);
                    TagType = getTagType(tag[0]);
                    switch (TagType)
                    {
                        case 1:
                            autocompleteMenu1.AppendMode = true;
                            autocompleteMenu1.ClearAll();
                            autocompleteMenu1.AddItem(new TagObject("Mode"));
                            autocompleteMenu1.AddItem(new TagObject("Status"));
                            autocompleteMenu1.AddItem(new TagObject("State"));
                            autocompleteMenu1.AddItem(new TagObject("NR"));
                            autocompleteMenu1.AddItem(new TagObject("AB"));
                            break;
                        case 2:
                            autocompleteMenu1.AppendMode = true;
                            autocompleteMenu1.ClearAll();
                            autocompleteMenu1.AddItem(new TagObject("Mode"));
                            autocompleteMenu1.AddItem(new TagObject("Status"));
                            autocompleteMenu1.AddItem(new TagObject("State"));
                            break;
                        case 8192:
                            autocompleteMenu1.AppendMode = true;
                            autocompleteMenu1.ClearAll();
                            autocompleteMenu1.AddItem(new TagObject("Mode"));
                            autocompleteMenu1.AddItem(new TagObject("Status"));
                            autocompleteMenu1.AddItem(new TagObject("State"));
                            autocompleteMenu1.AddItem(new TagObject("HH"));
                            autocompleteMenu1.AddItem(new TagObject("LL"));
                            autocompleteMenu1.AddItem(new TagObject("Hi"));
                            autocompleteMenu1.AddItem(new TagObject("Lo"));
                            break;
                    }
                }
                else
                {
                    if ((len == 2) && hasdot)
                    {
                        if (tag[1].ToUpper() == "MODE")
                        {
                            autocompleteMenu1.ClearAll();
                            autocompleteMenu1.AddItem(new TagObject("AUT"));
                            autocompleteMenu1.AddItem(new TagObject("MAN"));
                            autocompleteMenu1.AddItem(new TagObject("CAS"));
                        }
                        if (tag[1].ToUpper() == "STATUS")
                        {
                            autocompleteMenu1.ClearAll();
                            switch (TagType)
                            {
                                case 1:
                                    autocompleteMenu1.AddItem(new TagObject("AB_AL"));
                                    break;
                                case 8192:
                                    autocompleteMenu1.AddItem(new TagObject("HH_AL"));
                                    autocompleteMenu1.AddItem(new TagObject("LL_AL"));
                                    autocompleteMenu1.AddItem(new TagObject("HI_AL"));
                                    autocompleteMenu1.AddItem(new TagObject("LO_AL"));
                                    break;
                            }
                            
                        }
                    }
                }
            }
        }


        private int getTagType(string str)
        {

            if (str.ToUpper() == "BOOL")
            {
                return (int)1;
            }
            if (str.ToUpper() == "BYTE")
            {
                return (int)2;
            }
            if (str.ToUpper() == "REAL")
            {
                return (int)8192;
            }

            return 0;
        }
    }

    
}
