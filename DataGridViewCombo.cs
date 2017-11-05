using System;
using System.Windows.Forms;

namespace DataGridViewCombo
{
    public partial class DataGridViewCombo : Form
    {
        public DataGridViewCombo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// コンボボックスデータの型定義
        /// </summary>
        public class Fruits
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        /// <summary>
        /// データグリッド1行分の型定義
        /// </summary>
        public class Row
        {
            public int FruitsId { get; set; }
        }

        /// <summary>
        /// データグリッドにバインドされるデータ
        /// </summary>
        private BindingSource dataList = new BindingSource();

        private void DataGridViewCombo_Load(object sender, EventArgs e)
        {
            // コンボボックスデータの用意
            BindingSource bc = new BindingSource();
            bc.Add(new Fruits() { Id = 0, Name = "Apple" });
            bc.Add(new Fruits() { Id = 1, Name = "Orange" });
            bc.Add(new Fruits() { Id = 2, Name = "Grape" });

            // グリッドの列用
            DataGridViewComboBoxColumn cbx = new DataGridViewComboBoxColumn();
            cbx.HeaderText = "fruits";
            cbx.DataSource = bc;
            cbx.ValueMember = "Id";             //選択項目の値
            cbx.DisplayMember = "Name";         //コンボボックスの表示
            cbx.DataPropertyName = "FruitsId";  //データグリッドのデータとリンク

            dgv.Columns.Add(cbx);

            // データグリッドにバインドし値の設定取得
            dataList.DataSource = typeof(Row);
            dgv.DataSource = dataList;

            // 初期値として登録
            dataList.Add(new Row() { FruitsId = 1 });

        }

        private void btn_Click(object sender, EventArgs e)
        {
            foreach(Row o in dataList)
            {
                Console.WriteLine(o.FruitsId);
            }
        }
    }
}
