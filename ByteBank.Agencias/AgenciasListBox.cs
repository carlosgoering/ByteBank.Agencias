using ByteBank.Agencias.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ByteBank.Agencias
{
    public class AgenciasListBox : ListBox
    {
        private readonly MainWindow _janelaMae;
        public AgenciasListBox(MainWindow janelaMae)
        {
            _janelaMae = janelaMae ?? throw new ArgumentNullException(nameof(janelaMae)); 
        }
        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            base.OnSelectionChanged(e);
            var agenciaSelecionada = (Agencia)SelectedItem; // poderia ser as Agencia - CAST

            _janelaMae.textNumero.Text = agenciaSelecionada.Numero.ToString();
            _janelaMae.textNome.Text = agenciaSelecionada.Nome;
            _janelaMae.textTelefone.Text = agenciaSelecionada.Telefone;
            _janelaMae.textDescricao.Text = agenciaSelecionada.Descricao;
            _janelaMae.textEndereco.Text = agenciaSelecionada.Endereco;
        }
    }
}
