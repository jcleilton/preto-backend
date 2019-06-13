using System;

namespace ProcessesAPI.Model
{
    class Competidor
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string sobre_nome { get; set; }
        public DateTime data_nascimento { get; set; }
        public DateTime data_cadastro { get; set; }
        public float peso { get; set; }
        public int idade { get; set; }
        public int id_categoria { get; set; }
        public int id_equipe { get; set; }
        public int id_evento_ultimo { get; set; }
        public string senha { get; set; }
        public string email { get; set; }
        public int id_faixa { get; set; }
        public string whatsapp { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
        public string pais { get; set; }
        public string logradouro { get; set; }
        public string numero_casa { get; set; }
        public string observacao { get; set; }
        public string cep { get; set; }
        public bool Is_admin { get => is_admin; set => is_admin = value; }

        private bool is_admin = false;

        public Competidor()
        {
            
        }

    }
}