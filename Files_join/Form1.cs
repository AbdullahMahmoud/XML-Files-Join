using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Data;
using System.Linq.Expressions;

namespace Files_join
{
    public partial class Form1 : Form
    {
        List<XmlDocument> Files;
        List<Keys> Related_Keys;
        List<Related_DataSet> Arranged_Tables;
        List<string> File_Name;
        List<string> Primary_Key;
        List<string> Foreign_Key;
        List<DataSet> list_DS;
        List<DataTable> Cumulative_DataTable;
        bool Called_From_Left_Or_Right_Join , Called_From_Full_join;
        string ColumnName , Value;
        int position;
        public Form1()
        {
            InitializeComponent();
            this.BackgroundImage = System.Drawing.Image.FromFile("points_cubes_background_light_91691_1920x1080.jpg");
            Files = new List<XmlDocument>();
            Related_Keys = new List<Keys>();
            Arranged_Tables = new List<Related_DataSet>();
            Cumulative_DataTable = new List<DataTable>();
            File_Name=new List<string>();
            Primary_Key = new List<string>();
            Foreign_Key = new List<string>();
            Foreigntxt.Text = "Empty!";
            ColumnNametxt.Text = "Column Name";
            Valuetxt.Text = "Value";
            list_DS = new List<DataSet>();
            Called_From_Left_Or_Right_Join = false;
            Called_From_Full_join = false;
        }
        private void Upload_Btn_Click(object sender, EventArgs e)
        {
            DataSet DS1= new DataSet();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(openFileDialog1.FileName);
                bool IsNotEnteredBefore = true;
                XmlNodeList NewUpperTag = doc.ChildNodes;
                for (int i = 0 ; i < Files.Count&&IsNotEnteredBefore ; i++ )
                {
                    XmlNodeList TempUpperTag = Files[i].ChildNodes;
                    if(NewUpperTag[1].Name==TempUpperTag[1].Name)
                    {
                        IsNotEnteredBefore = false;
                    }
                }
                if (IsNotEnteredBefore)
                {
                    Files.Add(doc);
                    DS1.ReadXml(openFileDialog1.FileName);
                    File_Name.Add(openFileDialog1.FileName);
                    list_DS.Add(DS1);
                    dataGridView1.DataSource = DS1.Tables[0];
                    for (int i = 0; i < DS1.Tables[0].Columns.Count; i++)
                    {
                        dataGridView1.Columns[DS1.Tables[0].Columns[i].ColumnName.ToString()].DisplayIndex = i;
                    }
                    Number_of_file.Text = list_DS.Count.ToString();
                    Upload_Btn.Visible = false;
                    Deletebtn.Visible = false;
                    Savebtn.Visible = true;
                    PrimaryLabel.Visible = true;
                    Primarytxt.Visible = true;
                    ForeignLable.Visible = true;
                    Foreigntxt.Visible = true;
                }
                else
                    MessageBox.Show("This file is Entered before!");
            }
        }
        private void Inner_Join_Btn_Click(object sender, EventArgs e)
        {
            Get_Related_Files();
            Get_Arranged_Dataset();
            Cumulative_DataTable.Clear();
            if (Arranged_Tables.Count < 2)
                MessageBox.Show("No Related Files!");
            else
            {
                Cumulative_DataTable.Add(Arranged_Tables[0].DS_property.Tables[0]);
                for (int i = 0; i < Cumulative_DataTable[0].Columns.Count; i++ )
                {
                    if (Cumulative_DataTable[0].Columns[i].ColumnName.ToString()==ColumnName)
                    {
                        for (int j = 0; j < Cumulative_DataTable[0].Rows.Count; j++ )
                        { 
                            if (Cumulative_DataTable[0].Rows[j][i].ToString() != Value)
                            {
                                Cumulative_DataTable[0].Rows.Remove(Cumulative_DataTable[0].Rows[j]);
                                --j;
                            }
                        }
                        break;
                    }
                }
                for (int i = 1 ; i < Arranged_Tables.Count ; i++)
                {
                    Cumulative_DataTable.Add(new DataTable());
                    foreach (DataColumn col in Cumulative_DataTable[i - 1].Columns)
                    {
                        Cumulative_DataTable[i].Columns.Add(col.ColumnName);
                    }
                    int idx = 0;
                    foreach (DataColumn col in Arranged_Tables[i].DS_property.Tables[0].Columns)
                    {
                        if (idx != Arranged_Tables[i].Primary_Key_index_property)
                            Cumulative_DataTable[i].Columns.Add(col.ColumnName);
                        idx++;
                    }
                    int Current_Foreign_Key_Index;
                    if (i == 1)
                    {
                        Current_Foreign_Key_Index = Arranged_Tables[i - 1].Foregin_Key_index_property;
                    }
                    else
                    {
                        if (Arranged_Tables[i - 1].Foregin_Key_index_property < Arranged_Tables[i - 1].Primary_Key_index_property)
                        {
                            Current_Foreign_Key_Index = Cumulative_DataTable[i - 2].Columns.Count + Arranged_Tables[i - 1].Foregin_Key_index_property;
                        }
                        else
                        {
                            Current_Foreign_Key_Index = Cumulative_DataTable[i - 2].Columns.Count + Arranged_Tables[i - 1].Foregin_Key_index_property - 1;
                        }
                    }
                    for (int j = 0; j < Cumulative_DataTable[i - 1].Rows.Count; j++)
                    {
                        for (int k = 0; k < Arranged_Tables[i].DS_property.Tables[0].Rows.Count; k++)
                        {
                            DataRow NewRow = Cumulative_DataTable[i].NewRow();
                            if (Cumulative_DataTable[i - 1].Rows[j][Current_Foreign_Key_Index].ToString() == Arranged_Tables[i].DS_property.Tables[0].Rows[k][Arranged_Tables[i].Primary_Key_index_property].ToString())
                            {
                                int x = 0;
                                for (; x < Cumulative_DataTable[i - 1].Columns.Count; x++)
                                {
                                    NewRow[x] = Cumulative_DataTable[i - 1].Rows[j][x];
                                }
                                bool IsMatchTheCondition = true;
                                int idx1 = x;
                                for (x = 0; x < Arranged_Tables[i].DS_property.Tables[0].Columns.Count; x++, idx1++)
                                {
                                    if (Arranged_Tables[i].DS_property.Tables[0].Columns[x].ColumnName.ToString() == ColumnName && Arranged_Tables[i].DS_property.Tables[0].Rows[k][x].ToString() != Value)
                                    {
                                        IsMatchTheCondition = false;
                                        break;
                                    }
                                    if (x != Arranged_Tables[i].Primary_Key_index_property)
                                        NewRow[idx1] = Arranged_Tables[i].DS_property.Tables[0].Rows[k][x];
                                    else
                                        idx1--;
                                }
                                if(IsMatchTheCondition)
                                Cumulative_DataTable[i].Rows.Add(NewRow);
                            }
                        }
                    }
                }
                if (!Called_From_Left_Or_Right_Join)
                {
                    dataGridView1.DataSource = Cumulative_DataTable[Cumulative_DataTable.Count - 1];
                    for (int i = 0; i < Cumulative_DataTable[Cumulative_DataTable.Count - 1].Columns.Count; i++)
                    {
                        dataGridView1.Columns[Cumulative_DataTable[Cumulative_DataTable.Count - 1].Columns[i].ColumnName.ToString()].DisplayIndex = i;
                    }
                }
                else
                {
                    Called_From_Left_Or_Right_Join = false;
                }
            }
        }
        void Get_Related_Files()
        {
            Related_Keys.Clear();
            for (int i = 0; i < Files.Count; i++)
            {
                XmlNodeList UpperTag = Files[i].ChildNodes;
                XmlNodeList InnerTag = UpperTag[1].ChildNodes;
                XmlNodeList Childrens = InnerTag[0].ChildNodes;
                int Rela_Tbl_Idx = -1;
                int Fore_Key_idx = -1;
                int prim_Key_idex = -1;
                bool Found = false;
                for (int k = 0 ; k < Childrens.Count ; k++)
                {
                    string CurrentAttribute = Childrens[k].Name.ToString();
                    if (CurrentAttribute == Primary_Key[i])
                    {
                        prim_Key_idex = k;
                    }
                    else if (CurrentAttribute == Foreign_Key[i] && !Found)
                    {
                        Fore_Key_idx = k;
                        string[] name = CurrentAttribute.Split('_');
                        for (int x = 0; x < Files.Count; x++)
                        {
                            if (x == i)
                                continue;
                            XmlNodeList TmpUpperTag = Files[x].ChildNodes;
                            XmlNodeList TmpInnerTag = TmpUpperTag[1].ChildNodes;
                            if (name[0] == TmpInnerTag[0].Name)
                            {
                                Rela_Tbl_Idx = x;
                                Found = true;
                                break;
                            } 
                        }
                    }
                }
                Keys kee = new Keys(prim_Key_idex,Fore_Key_idx,Rela_Tbl_Idx);
                Related_Keys.Add(kee); 
            }
        }
        void Get_Arranged_Dataset()
        {
            Arranged_Tables.Clear();
            int idx=-1;
            for (int i = 0; i < Files.Count ; i++)
            {
                bool found = false;
                for (int j = 0 ; j < Related_Keys.Count ; j++)
                { 
                    if(Related_Keys[j].Related_table_index_property==i)
                    {
                        found =true;
                        break;
                    }
                }
                if (!found)
                {
                    idx = i;
                    break;
                }
            }
            for (int i = 0 ; i < Files.Count ; i++ )
            {
                DataSet newSet = new DataSet();
                newSet.ReadXml(File_Name[idx]);
                Related_DataSet Table = new Related_DataSet(Related_Keys[idx].Primary_Key_index_property , Related_Keys[idx].Foregin_Key_index_property , newSet);
                Arranged_Tables.Add(Table);
                idx = Related_Keys[idx].Related_table_index_property;
                if (idx == -1)
                    break;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            position=0;
            dataGridView1.DataSource = list_DS[0].Tables[0];
            for (int i = 0; i < list_DS[0].Tables[0].Columns.Count; i++)
            {
                dataGridView1.Columns[list_DS[0].Tables[0].Columns[i].ColumnName.ToString()].DisplayIndex = i;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            position = list_DS.Count - 1;
            dataGridView1.DataSource = list_DS[position].Tables[0];
            for (int i = 0; i < list_DS[position].Tables[0].Columns.Count; i++)
            {
                dataGridView1.Columns[list_DS[position].Tables[0].Columns[i].ColumnName.ToString()].DisplayIndex = i;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (position > 0)
            {
                position -= 1;
                dataGridView1.DataSource = list_DS[position].Tables[0];
                for (int i = 0; i < list_DS[position].Tables[0].Columns.Count; i++)
                {
                    dataGridView1.Columns[list_DS[position].Tables[0].Columns[i].ColumnName.ToString()].DisplayIndex = i;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (position <list_DS.Count-1 )
            {
                position += 1;
                dataGridView1.DataSource = list_DS[position].Tables[0];
                for (int i = 0; i < list_DS[position].Tables[0].Columns.Count; i++)
                {
                    dataGridView1.Columns[list_DS[position].Tables[0].Columns[i].ColumnName.ToString()].DisplayIndex = i;
                }
            }
        }
        private void Deletebtn_Click(object sender, EventArgs e)
        {
            Files.Clear();
            Related_Keys.Clear();
            Arranged_Tables.Clear();
            Cumulative_DataTable.Clear();
            File_Name.Clear();
            list_DS.Clear();
            dataGridView1.ClearSelection();
            Primary_Key.Clear();
            Foreign_Key.Clear();
            Number_of_file.Text = list_DS.Count.ToString();
            dataGridView1.DataSource = null;
            Primarytxt.Text = null;
            Foreigntxt.Text = "Empty!";
        }
        private void Savebtn_Click(object sender, EventArgs e)
        {
            if (Foreigntxt.Text.ToString().Contains("_") || Foreigntxt.Text == "Empty!")
            {
                bool CorrectPrimary = false, CorrectForeign = false;
                XmlNodeList UpperTag = Files[Files.Count - 1].ChildNodes;
                XmlNodeList InnerTag = UpperTag[1].ChildNodes;
                XmlNodeList Childrens = InnerTag[0].ChildNodes;
                if (Foreigntxt.Text == "Empty!")
                {
                    CorrectForeign = true;
                }
                for (int i = 0; i < Childrens.Count; i++)
                {
                   // MessageBox.Show(Childrens[i].Name.ToString() + "    " + Primarytxt.Text.ToString() + "    " + Foreigntxt.Text.ToString());
                    if (Childrens[i].Name.ToString() == Primarytxt.Text.ToString())
                    {
                        CorrectPrimary = true;
                    }
                    else if (Childrens[i].Name.ToString() == Foreigntxt.Text.ToString())
                    {
                        CorrectForeign = true;
                    }
                    if (CorrectForeign && CorrectPrimary)
                    {
                        Upload_Btn.Visible = true;
                        Deletebtn.Visible = true;
                        Savebtn.Visible = false;
                        PrimaryLabel.Visible = false;
                        Primarytxt.Visible = false;
                        ForeignLable.Visible = false;
                        Foreigntxt.Visible = false;
                        Primary_Key.Add(Primarytxt.Text.ToString());
                        Foreign_Key.Add(Foreigntxt.Text.ToString());
                        Primarytxt.Text = null;
                        Foreigntxt.Text = "Empty!";
                        break;
                    }
                }
                if (!CorrectPrimary)
                {
                    MessageBox.Show("The Primary Key is not correct!");
                    Primarytxt.Text = null;
                }
                if (!CorrectForeign)
                {
                    MessageBox.Show("The Foreign Key is not correct!");
                    Foreigntxt.Text = null;
                }
            }
            else
            {
                MessageBox.Show("The Foreign Key should be in form \"Table Name\"_\"Primary Key\"!");
                Foreigntxt.Text = null;
            }
        }
        private void DeleteTable_Click(object sender, EventArgs e)
        {
            if (list_DS.Count != 0)
            {
                Files.Remove(Files[position]);
                list_DS.Remove(list_DS[position]);
                File_Name.Remove(File_Name[position]);
                Primary_Key.Remove(Primary_Key[position]);
                Foreign_Key.Remove(Foreign_Key[position]);
                Number_of_file.Text = list_DS.Count.ToString();
                position = 0;
                if (list_DS.Count > 0)
                    dataGridView1.DataSource = list_DS[position].Tables[0];
                else
                    dataGridView1.DataSource = null;
            }
        }
        private void SetConbtn_Click(object sender, EventArgs e)
        {
            ColumnName = ColumnNametxt.Text.ToString();
            Value = Valuetxt.Text.ToString();
            ColumnNametxt.Text = "Column Name";
            Valuetxt.Text = "Value";
        }
        private void LeftJoin_Click(object sender, EventArgs e)
        {
            Called_From_Left_Or_Right_Join = true;
            Inner_Join_Btn_Click(sender, e);
            List<DataTable> Temp_Cumulative_DataTable = new List<DataTable>();
            if(Cumulative_DataTable.Count!=0)
            {
                Temp_Cumulative_DataTable.Add(Arranged_Tables[0].DS_property.Tables[0]);
                for (int i = 0; i < Temp_Cumulative_DataTable[0].Columns.Count; i++)
                {
                    if (Temp_Cumulative_DataTable[0].Columns[i].ColumnName.ToString() == ColumnName)
                    {
                        for (int j = 0; j < Temp_Cumulative_DataTable[0].Rows.Count; j++)
                        {
                            if (Temp_Cumulative_DataTable[0].Rows[j][i].ToString() != Value)
                            {
                                Temp_Cumulative_DataTable[0].Rows.Remove(Temp_Cumulative_DataTable[0].Rows[j]);
                                --j;
                            }
                        }
                        break;
                    }
                }
                for (int i = 1; i < Arranged_Tables.Count; i++)
                {
                    Temp_Cumulative_DataTable.Add(new DataTable());
                    foreach (DataColumn col in Temp_Cumulative_DataTable[i - 1].Columns)
                    {
                        Temp_Cumulative_DataTable[i].Columns.Add(col.ColumnName);
                    }
                    int idx = 0;
                    foreach (DataColumn col in Arranged_Tables[i].DS_property.Tables[0].Columns)
                    {
                        if (idx != Arranged_Tables[i].Primary_Key_index_property)
                            Temp_Cumulative_DataTable[i].Columns.Add(col.ColumnName);
                        idx++;
                    }
                    int Current_Foreign_Key_Index;
                    if (i == 1)
                    {
                        Current_Foreign_Key_Index = Arranged_Tables[i - 1].Foregin_Key_index_property;
                    }
                    else
                    {
                        if (Arranged_Tables[i - 1].Foregin_Key_index_property < Arranged_Tables[i - 1].Primary_Key_index_property)
                        {
                            Current_Foreign_Key_Index = Temp_Cumulative_DataTable[i - 2].Columns.Count + Arranged_Tables[i - 1].Foregin_Key_index_property;
                        }
                        else
                        {
                            Current_Foreign_Key_Index = Temp_Cumulative_DataTable[i - 2].Columns.Count + Arranged_Tables[i - 1].Foregin_Key_index_property - 1;
                        }
                    }
                    for (int j = 0; j < Temp_Cumulative_DataTable[i - 1].Rows.Count; j++)
                    {
                        bool IsJoin = false;
                        for (int k = 0; k < Arranged_Tables[i].DS_property.Tables[0].Rows.Count; k++)
                        {
                            DataRow NewRow1 = Temp_Cumulative_DataTable[i].NewRow();
                            if (Temp_Cumulative_DataTable[i - 1].Rows[j][Current_Foreign_Key_Index].ToString() == Arranged_Tables[i].DS_property.Tables[0].Rows[k][Arranged_Tables[i].Primary_Key_index_property].ToString())
                            {
                                int x = 0;
                                for (; x < Temp_Cumulative_DataTable[i - 1].Columns.Count; x++)
                                {
                                    NewRow1[x] = Temp_Cumulative_DataTable[i - 1].Rows[j][x];
                                }
                                bool IsMatchTheCondition = true;
                                int idx1 = x;
                                for (x = 0; x < Arranged_Tables[i].DS_property.Tables[0].Columns.Count; x++, idx1++)
                                {
                                    if (Arranged_Tables[i].DS_property.Tables[0].Columns[x].ColumnName.ToString() == ColumnName && Arranged_Tables[i].DS_property.Tables[0].Rows[k][x].ToString() != Value)
                                    {
                                        IsMatchTheCondition = false;
                                        break;
                                    }
                                    if (x != Arranged_Tables[i].Primary_Key_index_property)
                                        NewRow1[idx1] = Arranged_Tables[i].DS_property.Tables[0].Rows[k][x];
                                    else
                                        idx1--;
                                }
                                if (IsMatchTheCondition)
                                    Temp_Cumulative_DataTable[i].Rows.Add(NewRow1);
                                IsJoin = true;
                            }
                        }
                        if (!IsJoin)
                        {
                            DataRow NewRow2 = Cumulative_DataTable[Cumulative_DataTable.Count - 1].NewRow();
                            for (int x=0 ; x < Temp_Cumulative_DataTable[i - 1].Columns.Count; x++)
                            {
                                NewRow2[x] = Temp_Cumulative_DataTable[i - 1].Rows[j][x];
                            }
                            bool IsMatchTheCondition = true;
                            for (int x = 0; x <Cumulative_DataTable[Cumulative_DataTable.Count - 1].Columns.Count ; x++)
                            {
                                if (Cumulative_DataTable[Cumulative_DataTable.Count - 1].Columns[x].ColumnName.ToString() == ColumnName && NewRow2[x].ToString()!=Value)
                                {
                                    IsMatchTheCondition = false;
                                    break;
                                }
                            }
                            if(IsMatchTheCondition)
                            Cumulative_DataTable[Cumulative_DataTable.Count - 1].Rows.Add(NewRow2);
                        }    
                    }
                }
                if (!Called_From_Full_join)
                {
                    dataGridView1.DataSource = Cumulative_DataTable[Cumulative_DataTable.Count - 1];
                    for (int i = 0; i < Cumulative_DataTable[Cumulative_DataTable.Count - 1].Columns.Count; i++)
                    {
                        dataGridView1.Columns[Cumulative_DataTable[Cumulative_DataTable.Count - 1].Columns[i].ColumnName.ToString()].DisplayIndex = i;
                    }
                }
            }
        }
        private void RightJoin_Click(object sender, EventArgs e)
        {
            List<DataTable> Temp_Cumulative_DataTable = new List<DataTable>();
            DataTable Temp_Right_Cumulative_DataTable=new DataTable();
            if (Arranged_Tables.Count < 2)
                MessageBox.Show("No Related Files!");
            else
            {
                for (int i = 0 ; i < Arranged_Tables.Count ; i++)
                {
                    int idx = 0;
                    foreach (DataColumn col in Arranged_Tables[i].DS_property.Tables[0].Columns)
                    {
                        if (idx != Arranged_Tables[i].Foregin_Key_index_property)
                            Temp_Right_Cumulative_DataTable.Columns.Add(col.ColumnName);
                        idx++;
                    }
                }
                Temp_Cumulative_DataTable.Add(Arranged_Tables[Arranged_Tables.Count-1].DS_property.Tables[0]);
                for (int i = 0; i < Temp_Cumulative_DataTable[0].Columns.Count; i++)
                {
                    if (Temp_Cumulative_DataTable[0].Columns[i].ColumnName.ToString() == ColumnName)
                    {
                        for (int j = 0; j < Temp_Cumulative_DataTable[0].Rows.Count; j++)
                        {
                            if (Temp_Cumulative_DataTable[0].Rows[j][i].ToString() != Value)
                            {
                                Temp_Cumulative_DataTable[0].Rows.Remove(Temp_Cumulative_DataTable[0].Rows[j]);
                                --j;
                            }
                        }
                        break;
                    }
                }
                for (int i = Arranged_Tables.Count-2 ; i >= 0 ; i--)
                {
                    Temp_Cumulative_DataTable.Add(new DataTable());
                    int idx = 0;
                    foreach (DataColumn col in Arranged_Tables[i].DS_property.Tables[0].Columns)
                    {
                        if (idx != Arranged_Tables[i].Foregin_Key_index_property)
                            Temp_Cumulative_DataTable[Arranged_Tables.Count - i - 1].Columns.Add(col.ColumnName);
                        idx++;
                    }
                    foreach (DataColumn col in Temp_Cumulative_DataTable[Arranged_Tables.Count - i - 2].Columns)
                    {
                        Temp_Cumulative_DataTable[Arranged_Tables.Count-i-1].Columns.Add(col.ColumnName);
                    }
                    int Current_Primary_Key_Index;
                    if (i == Arranged_Tables.Count - 2)
                    {
                        Current_Primary_Key_Index = Arranged_Tables[i + 1].Primary_Key_index_property;
                    }
                    else
                    {
                        if (Arranged_Tables[i + 1].Foregin_Key_index_property > Arranged_Tables[i + 1].Primary_Key_index_property)
                        {
                            Current_Primary_Key_Index = Arranged_Tables[i + 1].Primary_Key_index_property;
                        }
                        else
                        {
                            Current_Primary_Key_Index = Arranged_Tables[i + 1].Primary_Key_index_property - 1;
                        }
                    }
                    for (int j = 0; j < Temp_Cumulative_DataTable[Arranged_Tables.Count - i - 2].Rows.Count; j++)
                    {
                        bool IsJoin = false;
                        for (int k = 0; k < Arranged_Tables[i].DS_property.Tables[0].Rows.Count; k++)
                        {
                            DataRow NewRow1 = Temp_Cumulative_DataTable[Arranged_Tables.Count - i - 1].NewRow();
                            if (Temp_Cumulative_DataTable[Arranged_Tables.Count - i - 2].Rows[j][Current_Primary_Key_Index].ToString() == Arranged_Tables[i].DS_property.Tables[0].Rows[k][Arranged_Tables[i].Foregin_Key_index_property].ToString())
                            {
                                bool IsMatchTheCondition = true;
                                int x = 0;
                                int idx1 = x;
                                for ( ; x < Arranged_Tables[i].DS_property.Tables[0].Columns.Count; x++ , idx1++)
                                {
                                    if (Arranged_Tables[i].DS_property.Tables[0].Columns[x].ColumnName.ToString() == ColumnName && Arranged_Tables[i].DS_property.Tables[0].Rows[k][x].ToString() != Value)
                                    {
                                        IsMatchTheCondition = false;
                                        break;
                                    }
                                    if (x != Arranged_Tables[i].Foregin_Key_index_property)
                                        NewRow1[idx1] = Arranged_Tables[i].DS_property.Tables[0].Rows[k][x];
                                    else
                                        idx1--;
                                }
                                for (x=0 ; x < Temp_Cumulative_DataTable[Arranged_Tables.Count - i - 2].Columns.Count && IsMatchTheCondition; x++, idx1++)
                                {
                                    NewRow1[idx1] = Temp_Cumulative_DataTable[Arranged_Tables.Count - i - 2].Rows[j][x];
                                }
                                if (IsMatchTheCondition)
                                    Temp_Cumulative_DataTable[Arranged_Tables.Count - i - 1].Rows.Add(NewRow1);
                                IsJoin = true;
                            }
                        }
                        if (!IsJoin)
                        {
                            DataRow NewRow2 = Temp_Right_Cumulative_DataTable.NewRow();
                            int idx2 = Temp_Right_Cumulative_DataTable.Columns.Count - 1;
                            for (int x = Temp_Cumulative_DataTable[Arranged_Tables.Count - i - 2].Columns.Count-1 ; x >=0 ; x--)
                            {
                                NewRow2[idx2] = Temp_Cumulative_DataTable[Arranged_Tables.Count - i - 2].Rows[j][x];
                                idx2--;
                            }
                            bool IsMatchTheCondition = true;
                            for (int x = 0; x < Temp_Right_Cumulative_DataTable.Columns.Count; x++)
                            {
                                if (Temp_Right_Cumulative_DataTable.Columns[x].ColumnName.ToString() == ColumnName && NewRow2[x].ToString() != Value)
                                {
                                    IsMatchTheCondition = false;
                                    break;
                                }
                            }
                            if (IsMatchTheCondition)
                                Temp_Right_Cumulative_DataTable.Rows.Add(NewRow2);
                        }
                    }
                }
                if (!Called_From_Full_join)
                {
                    for (int i = 0; i < Temp_Right_Cumulative_DataTable.Rows.Count; i++)
                    {
                        DataRow row = Temp_Cumulative_DataTable[Temp_Cumulative_DataTable.Count - 1].NewRow();
                        int idx = Temp_Cumulative_DataTable[Temp_Cumulative_DataTable.Count - 1].Columns.Count - 1;
                        for (int j = Temp_Right_Cumulative_DataTable.Columns.Count-1 ; j >=0 ; j-- , idx--)
                            row[idx] = Temp_Right_Cumulative_DataTable.Rows[i][j];
                            Temp_Cumulative_DataTable[Temp_Cumulative_DataTable.Count - 1].Rows.Add(row);
                    }
                        dataGridView1.DataSource = Temp_Cumulative_DataTable[Temp_Cumulative_DataTable.Count - 1];
                    for (int i = 0; i < Temp_Cumulative_DataTable[Temp_Cumulative_DataTable.Count - 1].Columns.Count; i++)
                    {
                        dataGridView1.Columns[Temp_Cumulative_DataTable[Temp_Cumulative_DataTable.Count - 1].Columns[i].ColumnName.ToString()].DisplayIndex = i;
                    }
                }
                else
                    Called_From_Full_join = false;
            }
        }
        private void FullJoinbtn_Click(object sender, EventArgs e)
        {
            Called_From_Full_join = true;
            Inner_Join_Btn_Click(sender, e);
            LeftJoin_Click(sender, e);
            RightJoin_Click(sender, e);
            dataGridView1.DataSource = Cumulative_DataTable[Cumulative_DataTable.Count - 1];
            for (int i = 0; i < Cumulative_DataTable[Cumulative_DataTable.Count - 1].Columns.Count; i++)
            {
                dataGridView1.Columns[Cumulative_DataTable[Cumulative_DataTable.Count - 1].Columns[i].ColumnName.ToString()].DisplayIndex = i;
            }
        }
    }
}
