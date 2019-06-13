using System;

namespace ProcessesAPI.Model
{
    class Categoria
    {
        public int id { get; set; }
        public string nome { get; set; }
        public int id_faixa { get; set; }
        public int tempo_luta_em_minuto { get; set; }
        public int idade_inicial { get; set; }
        public int idade_final { get; set; }
        public float peso_inicial { get; set; }
        public float peso_final { get; set; }
        public bool is_gui { get; set; }
       

        public Categoria()
        {
            
        }

    }
}