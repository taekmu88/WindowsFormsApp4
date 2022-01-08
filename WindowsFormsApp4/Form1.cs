using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            List<Donation> donationList = new List<Donation>();

            // StreamReader로 데이타를 읽는다
            StreamReader rd = new StreamReader("data.txt");


            while (!rd.EndOfStream)
            {
                string line = rd.ReadLine();

                string[] cols = line.Split(',');


                // 컬럼들로 Donation 객체를 만든다
                Donation d = new Donation();

                d.Id = cols[0];
                d.Name = cols[1];
                d.Grade = cols[2];                
                d.Amount = double.Parse(cols[3].Substring(1));


                // Donation 리스트에 Donation 객체를 추가한다
                donationList.Add(d);

            }

            // StreamReader를 닫는다
            rd.Close();

            // DataGridView의 DataSource 속성에 Donation 리스트 (컬렉션)을 지정하여
            // 데이타 바인딩을 수행한다
            dataGridView1.DataSource = donationList;


        }
    }
    // Donation 클래스
    // 각 컬럼이 하나의 속성에 대응된다
    class Donation
    {
        public string Id { get; set; }   // Id 라는 속성
        public string Name { get; set; }  // Name 이라는 속성
        public string Grade { get; set; }        
        public double Amount { get; set; }
    }

}
