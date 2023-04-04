using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Timers;

namespace GestaoManual.Producao.PinturaImersao
{
    public partial class ProcessoPintura : System.Web.UI.Page
    {
        private MySqlConnection connection = new MySqlConnection(SiteMaster.ConnectionString);
        static string dataHoraIni;

        protected void Page_Load(object sender, EventArgs e)
        {
            txtLotePecas.AutoPostBack= false;
            try
            {
                connection.Open();
                int id = Convert.ToInt32(Session["Login"].ToString());

                var reader = new MySqlCommand("select id, substring_index(nome, ' ', -1) as UltimoNome, substring_index(nome, ' ', 1) as PrimeiroNome from funcionarios WHERE id=" + id, connection).ExecuteReader();
                while(reader.Read())
                {
                    var segundo = new ListItem(reader.GetString("UltimoNome"), reader.GetInt32("id").ToString());
                    var primeiro = new ListItem(reader.GetString("PrimeiroNome"), reader.GetInt32("id").ToString());
                    var nome = segundo + ", " + primeiro;
                    lblNome.Text = nome;
                }
                connection.Close();

                connection.Open();
                int idP = Convert.ToInt32(Session["Produto"].ToString());
                var rdr = new MySqlCommand($"SELECT id, descricao FROM produto WHERE id={idP}", connection).ExecuteReader();
                while(rdr.Read())
                {
                    var produto = new ListItem(rdr.GetString("descricao"), rdr.GetInt32("id").ToString());
                    lblProduto.Text = produto.ToString();
                }
                connection.Close();

                connection.Open();
                int idS = Convert.ToInt32(Session["Setor"].ToString());
                var ler = new MySqlCommand($"SELECT id, descricao FROM setor WHERE id={idS}", connection).ExecuteReader();
                while (ler.Read())
                {
                    var setor = new ListItem(ler.GetString("descricao"), ler.GetInt32("id").ToString());
                    lblSetor.Text = setor.ToString();
                }
                connection.Close();

                connection.Open();
                var reader2 = new MySqlCommand($"SELECT op.id, op.registro, op.idMaquina, ma.id, ma.nome FROM operador AS op, maquina AS ma WHERE op.id = ma.id AND op.registro={id}", connection).ExecuteReader();
                while (reader2.Read())
                {
                    var maquina = new ListItem(reader2.GetString("nome"), reader2.GetInt32("registro").ToString());
                    lblMaquina.Text = maquina.ToString();
                }
                connection.Close();
            }
            catch(Exception ex)
            {
                SiteMaster.AlertPersonalizado(this, "Aconteceu um erro inesperado:\n" + ex);
            }

        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["Login"].ToString());

            DateTime dataFim = DateTime.Now;
            lblTeste.Text = teste.Value;
            //LabelLotePecas.Text = lblLoteP.Value;

            int Qts = Convert.ToInt32(txtQts.Text);
            int PecasBoas = Convert.ToInt32(txtPecasBoas.Text);

            if (TodosPreenchidos() == true)
            {
                if(PecasBoas <= Qts)
                {
                    var producao = new Classes.Producao();
                    producao.IdProduto = Convert.ToInt32(Session["produto"].ToString());
                    producao.DataHoraIni = Convert.ToDateTime(Session["DataHoraInicio"].ToString());
                    producao.DataHoraFin = dataFim;
                    producao.NumPecas = Convert.ToInt32(txtQts.Text);
                    producao.NumPecasBoas = Convert.ToInt32(txtPecasBoas.Text);
                    producao.LotePecas = txtLotePecas.Text;
                    producao.IDOperador = id;
                    producao.IdSetor = Convert.ToInt32(Session["Setor"].ToString());
                    producao.IDMaquina = lblMaquina.Text;
                    producao.LoteTinta = lblTeste.Text;
                    new Negocio.Producao().FinalizarProcesso(producao);

                    SiteMaster.AlertPersonalizado(this, "Processo finalizado com sucesso");

                    Response.Redirect("../EscolherSetor.aspx");
                }
                else
                {
                    SiteMaster.AlertPersonalizado(this, "Quantidade de peças boas é maior que a quantidade de peças produzidas!");
                }

            }
            else
            {
                SiteMaster.AlertPersonalizado(this, "Todos os campos precisam estar preenchidos!");
            }
        }

        public bool TodosPreenchidos()
        {
            if ((txtQts.Text == "") || (txtPecasBoas.Text == "") || (txtLotePecas.Text == "") || (lblTeste.Text == ""))
            {
                SiteMaster.AlertPersonalizado(this, "Todos os campos precisam estar preenchidos!");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}