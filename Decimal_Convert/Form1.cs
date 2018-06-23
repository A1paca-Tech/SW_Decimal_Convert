using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Decimal_Convert
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lb_show.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tb_10.Text == "" || tb_n.Text == "") { MessageBox.Show("欄位不能為空!", "Alert"); return; }
            if (int.Parse(tb_n.Text) < 2 || int.Parse(tb_n.Text) > 20) { MessageBox.Show("基底範圍為2~20!", "Alert"); return; }
            if (int.Parse(tb_n.Text) == 10) { return; }

            try
            {
                int nb_10 = int.Parse(tb_10.Text);  //十進制數字
                int nb_n = int.Parse(tb_n.Text);    //欲轉換成N進制
                

                if (int.Parse(tb_n.Text) < 10) { lb_show.Text = "答案為：\r\n" + f_2_9(nb_10, nb_n); }  //2~9進制
                if (int.Parse(tb_n.Text) > 10) { lb_show.Text = "答案為：\r\n" + f_11_20(nb_10, nb_n); }  //11~20進制


            }catch{ MessageBox.Show("Error!", "Error!"); }
        }

/********************************************************************************************************/

        string f_2_9(int nb_10 , int nb_n){                //2~9進制
            try
            {
                int arr_q = nb_10;  //除法迴圈 商數
                int arr_r;          //除法迴圈 餘數
                string my_ans="";

                while (true){
                    arr_r = arr_q % nb_n;
                    arr_q = arr_q / nb_n;
                    my_ans = (arr_r).ToString() + my_ans;
                    if (arr_q < nb_n){ my_ans = (arr_q).ToString() + my_ans; break; }    //若是不能再除則break
                }

                return my_ans.TrimStart('0');
            }catch { MessageBox.Show("Error!", "Error!"); return ""; }
        }

        string f_11_20(int nb_10, int nb_n){               //11~20進制
            try
            {
                string[] my_string_arr = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J"};  //20進制
                int[] arr_q = new int[(nb_10 / nb_n) + 2];  //除法迴圈 商數
                int[] arr_r = new int[(nb_10 / nb_n) + 2];  //除法迴圈 餘數
                string my_ans = "";

                int i = 1; arr_q[0] = nb_10;

                while (true)
                {
                    arr_q[i] = arr_q[i - 1] / nb_n;
                    arr_r[i] = arr_q[i - 1] % nb_n;
                    my_ans = (my_string_arr[arr_r[i]]).ToString() + my_ans;
                    if (arr_q[i] < nb_n) { my_ans = (my_string_arr[arr_q[i]]).ToString() + my_ans; break; }    //若是不能再除則break
                    i++;
                }

                return my_ans.TrimStart('0');
            }
            catch { MessageBox.Show("Error!", "Error!"); return ""; }
        }
/********************************************************************************************************/

    }
}
