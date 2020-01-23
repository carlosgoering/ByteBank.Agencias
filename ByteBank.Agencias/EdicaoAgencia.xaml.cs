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
            RoutedEventHandler dialogResultTrue = (o, e) => DialogResult = true;
            RoutedEventHandler dialogResultFalse = (o, e) => DialogResult = false;

            var salvarEventHandler = dialogResultTrue + Fechar;
            var cancelarEventHandler = dialogResultFalse + Fechar;
            ButtonSalvar.Click += salvarEventHandler;
            ButtonCancelar.Click += cancelarEventHandler;

            textNome.Validacao += ValidarCampoNulo;
            textNumero.Validacao += ValidarCampoNulo;
            textNumero.Validacao += ValidarSomenteDigito;
            textTelefone.Validacao += ValidarCampoNulo;
            textDescricao.Validacao += ValidarCampoNulo;
            textEndereco.Validacao += ValidarCampoNulo;
        }
        private bool ValidarSomenteDigito(string texto)
        {
            return texto.All(char.IsDigit);
        }
        private bool ValidarCampoNulo(string texto)
        {
            return !string.IsNullOrEmpty(texto);

        }
        private void Fechar(object sender, EventArgs e) =>
            Close();
    }
}
