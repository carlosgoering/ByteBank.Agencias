using ByteBank.Agencias.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ByteBank.Agencias
{
    /// <summary>
    /// Interaction logic for EdicaoAgencia.xaml
    /// </summary>
    public partial class EdicaoAgencia : Window
    {
        private readonly Agencia _agencia;
        public EdicaoAgencia(Agencia agencia)
        {
            InitializeComponent();

            _agencia = agencia ?? throw new ArgumentNullException(nameof(Agencia));
            AtualizarAgencia();
            AtualizarControles();
        }

        private void AtualizarAgencia()
        {
            textNumero.Text = _agencia.Numero.ToString();
            textNome.Text = _agencia.Nome;
            textTelefone.Text = _agencia.Telefone;
            textDescricao.Text = _agencia.Descricao;
            textEndereco.Text = _agencia.Endereco;
        }
        private void AtualizarControles()
        {
            Delegate okEventHandler = (RoutedEventHandler)ButtonSalvar_Click + Fechar;
            var cancelarEventHandler = (RoutedEventHandler)ButtonCancelar_Click + Fechar;

            ButtonSalvar.Click += new RoutedEventHandler(ButtonSalvar_Click);
            ButtonCancelar.Click += new RoutedEventHandler(ButtonCancelar_Click);
        }

        private void ButtonCancelar_Click(object sender, EventArgs e) =>
            DialogResult = true;

        private void ButtonSalvar_Click(object sender, EventArgs e) =>
            DialogResult = false;

        private void Fechar(object sender, EventArgs e) =>
            Close();


    }
}
