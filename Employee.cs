using System;
using System.Data;
using System.Windows.Forms;
using System.Xml;

namespace Lab3_Evdoshenko
{
    public partial class Employee : Form
    {

        

        public Employee()
        {
            InitializeComponent();
        }

        private void update_Click(object sender, EventArgs e)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("employee.xml");

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ФИО");
            table.Columns.Add("Год_рождения");
            table.Columns.Add("Домашний_адрес");
            table.Columns.Add("Телефон");
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("employee.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            if (xRoot != null)
            {
                foreach (XmlElement xnode in xRoot)
                {
                    var employee = new Helpers.Employee();
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        if (childnode.Name == "Домашний_адрес")
                        {
                            employee.address = childnode.InnerText;
                        }
                        if (childnode.Name == "Телефон")
                        {
                            employee.number = childnode.InnerText;
                        }
                        if (childnode.Name == "Год_рождения")
                        {
                            employee.birth = childnode.InnerText;
                        }
                        if (childnode.Name == "ФИО")
                        {
                            employee.FIO = childnode.InnerText;
                        }
                    }
                    table.Rows.Add(new object[] {
                        employee.FIO, 
                        employee.birth, 
                        employee.address, 
                        employee.number});
                    dataGridView1.DataSource = table;
                }
            }
        }

        private void dataGridView1_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                label5.Text = "Никто не выбран";
            }
            else
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load("employee.xml");
                XmlElement xRoot = xDoc.DocumentElement;
                if (xRoot != null)
                {
                    XmlElement childP = null;
                    foreach (XmlElement xnode in xRoot)
                    {
                        Console.WriteLine(xnode.InnerText);
                        XmlNode child = null;
                        var employee = new Helpers.Employee();
                        foreach (XmlNode childnode in xnode.ChildNodes)
                        {
                            Console.WriteLine(childnode.InnerText);
                            Console.WriteLine(label5.Text);
                            Console.WriteLine(childnode.InnerText.Equals(textBox1.Text));
                            if (childnode.Name == "ФИО" && childnode.InnerText.Equals(textBox1.Text))
                            {
                                Console.WriteLine(111);
                                child = childnode;
                                Console.WriteLine(child.InnerText);
                                return;
                            }
                        }
                        Console.WriteLine(child.InnerText);
                        if (child != null)
                        {
                            Console.WriteLine(222);
                            childP = xnode;
                            return;
                        }
                        
                    }
                    if (childP != null)
                    {
                        Console.WriteLine(333);
                        xRoot.RemoveChild(childP);
                        xDoc.Save("employee.xml");
                    }
                }
                label5.Text = "";
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
