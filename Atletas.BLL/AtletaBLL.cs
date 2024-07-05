using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using Atletas.DAL;
using Atletas.DTO;

namespace Atletas.BLL
{
    public class AtletaBLL : IAtleta<Atleta>
    {
        public Atleta GetAtletaId(int id)
        {
            try
            {
                string sql = "SELECT id, nome, apelido, nascimento, " +
                "altura, peso, posicao, numero_camisa " +
                "FROM tbl_atletas WHERE id = " + id;
                DataTable tabela = new DataTable();
                tabela = AcessoDB.GetDataTable(sql);
                return GetAtleta(tabela);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Atleta GetAtleta(DataTable tabela)
        {
            try
            {
                Atleta _Atleta = new Atleta();

                if (tabela.Rows.Count > 0)
                {
                    _Atleta.id = Convert.ToInt32(tabela.Rows[0]["id"]);
                    _Atleta.nome = Convert.ToString(tabela.Rows[0]["nome"]);
                    _Atleta.apelido = Convert.ToString(tabela.Rows[0]["apelido"]);
                    _Atleta.nascimento = Convert.ToDateTime(tabela.Rows[0]["nascimento"]);
                    _Atleta.altura = Convert.ToDouble(tabela.Rows[0]["altura"]);
                    _Atleta.peso = Convert.ToDouble(tabela.Rows[0]["peso"]);
                    _Atleta.posicao = Convert.ToString(tabela.Rows[0]["posicao"]);
                    _Atleta.numero_camisa = Convert.ToInt32(tabela.Rows[0]["numero_camisa"]);
                    return _Atleta;
                }
                else
                {
                    _Atleta = null;
                    return _Atleta;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Atleta> Exibir()
        {
            try
            {
                string sql = "SELECT * FROM tbl_atletas";
                DataTable tabela = new DataTable();
                tabela = AcessoDB.GetDataTable(sql);
                return GetListaAtleta(tabela);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Atleta> GetListaAtleta(DataTable tabela)
        {
            try
            {
                List<Atleta> listaAtleta = new List<Atleta>();

                int i = 0;
                dynamic registros = tabela.Rows.Count;
                
                if (registros > 0)
                {
                    foreach (DataRow drRow in tabela.Rows)
                    {
                        Atleta _Atleta = new Atleta();

                        _Atleta.id = Convert.ToInt32(tabela.Rows[0]["id"]);
                        _Atleta.nome = Convert.ToString(tabela.Rows[0]["nome"]);
                        _Atleta.apelido = Convert.ToString(tabela.Rows[0]["apelido"]);
                        _Atleta.nascimento = Convert.ToDateTime(tabela.Rows[0]["nascimento"]);
                        _Atleta.altura = Convert.ToDouble(tabela.Rows[0]["altura"]);
                        _Atleta.peso = Convert.ToDouble(tabela.Rows[0]["peso"]);
                        _Atleta.posicao = Convert.ToString(tabela.Rows[0]["posicao"]);
                        _Atleta.numero_camisa = Convert.ToInt32(tabela.Rows[0]["numero_camisa"]);

                        listaAtleta.Add(_Atleta);
                    }
                    
                    while (i <= registros)
                    {
                        Atleta _Atleta = new Atleta();

                        _Atleta.id = Convert.ToInt32(tabela.Rows[i]["id"]);
                        _Atleta.nome = Convert.ToString(tabela.Rows[i]["nome"]);
                        _Atleta.apelido = Convert.ToString(tabela.Rows[i]["apelido"]);
                        _Atleta.nascimento = Convert.ToDateTime(tabela.Rows[i]["nascimento"]);
                        _Atleta.altura = Convert.ToDouble(tabela.Rows[i]["altura"]);
                        _Atleta.peso = Convert.ToDouble(tabela.Rows[i]["peso"]);
                        _Atleta.posicao = Convert.ToString(tabela.Rows[i]["posicao"]);
                        _Atleta.numero_camisa = Convert.ToInt32(tabela.Rows[i]["numero_camisa"]);

                        listaAtleta.Add(_Atleta);

                        i += i;
                    }

                    return listaAtleta;
                }
                else
                {
                    listaAtleta = null;
                    return listaAtleta;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ConsultarPorID(int id)
        {
            string sql = "SELECT id, nome, apelido, nascimento, " +
            "altura, peso, posicao, numero_camisa " +
            "FROM tbl_atletas WHERE id = " + id;
            
            try
            {
                return AcessoDB.GetDataTable(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Consultar(string nome)
        {
            string sql = "SELECT id, nome FROM tbl_atletas WHERE nome LIKE '" + nome + "%'" + " ORDER BY nome";
            
            try
            {
                return AcessoDB.GetDataTable(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Incluir(Atleta oAtleta)
        {
            string sql = "";
            try
            {
                string[] parametrosNomes = new string[7];
                parametrosNomes[0] = "@nome";
                parametrosNomes[1] = "@apelido";
                parametrosNomes[2] = "@nascimento";
                parametrosNomes[3] = "@altura";
                parametrosNomes[4] = "@peso";
                parametrosNomes[5] = "@posicao";
                parametrosNomes[6] = "@numero_camisa";
                
                string[] parametrosValores = new string[7];
                parametrosValores[0] = oAtleta.nome;
                parametrosValores[1] = oAtleta.apelido;
                parametrosValores[2] = oAtleta.nascimento.ToString();
                parametrosValores[3] = oAtleta.altura.ToString();
                parametrosValores[4] = oAtleta.peso.ToString();
                parametrosValores[5] = oAtleta.posicao.ToString();
                parametrosValores[6] = oAtleta.numero_camisa.ToString();

                sql = "INSERT INTO tbl_atletas " +
                "(nome, apelido, nascimento, altura, " +
                "peso, posicao, numero_camisa) " +
                "VALUES " +
                "(@nome, @apelido, @nascimento, @altura, " +
                "@peso, @posicao, @numero_camisa)";
                AcessoDB.CRUD(sql, parametrosNomes, parametrosValores);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Alterar(Atleta oAtleta)
        {
            string sql = "";

            try
            {
                string[] parametrosNomes = new string[8];
                parametrosNomes[0] = "@id";
                parametrosNomes[1] = "@nome";
                parametrosNomes[2] = "@apelido";
                parametrosNomes[3] = "@nascimento";
                parametrosNomes[4] = "@altura";
                parametrosNomes[5] = "@peso";
                parametrosNomes[6] = "@posicao";
                parametrosNomes[7] = "@numero_camisa";

                string[] parametrosValores = new string[8];
                parametrosValores[0] = oAtleta.id.ToString();
                parametrosValores[1] = oAtleta.nome;
                parametrosValores[2] = oAtleta.apelido;
                parametrosValores[3] = oAtleta.nascimento.ToString();
                parametrosValores[4] = oAtleta.altura.ToString();
                parametrosValores[5] = oAtleta.peso.ToString();
                parametrosValores[6] = oAtleta.posicao.ToString();
                parametrosValores[7] = oAtleta.numero_camisa.ToString();

                sql = "UPDATE tbl_atletas SET " +
                "nome = @nome, " +
                "apelido = @apelido, " +
                "nascimento = @nascimento, " +
                "altura = @altura, " +
                "peso = @peso, " +
                "posicao = @posicao, " +
                "numero_camisa = @numero_camisa " +
                "WHERE id = @id";
                AcessoDB.CRUD(sql, parametrosNomes, parametrosValores);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Excluir(Atleta oAtleta)
        {
            string sql = "";
            try
            {
                string[] parametrosNomes = new string[1];
                parametrosNomes[0] = "@id";
                string[] parametrosValores = new string[1];
                parametrosValores[0] = oAtleta.id.ToString();

                sql = "DELETE FROM tbl_atletas WHERE id=@id";
                AcessoDB.CRUD(sql, parametrosNomes, parametrosValores);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ExibirTodos()
        {
            string sql = "SELECT * FROM tbl_atletas";

            try
            {
                return AcessoDB.GetDataTable(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
