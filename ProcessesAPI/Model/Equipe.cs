using System;

namespace ProcessesAPI.Model
{
    class Equipe
    {
        public int id { get; set; }
        public string nome { get; set; }
        public DateTime data_cadastro { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
        public string pais { get; set; }
        public string logradouro { get; set; }
        public string numero_casa { get; set; }
        public string observacao { get; set; }
        public string cep { get; set; }
       

        public Equipe()
        {
            
        }

    }
}