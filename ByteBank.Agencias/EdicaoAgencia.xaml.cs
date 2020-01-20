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

            textNome.TextChanged += TextNome_TextChanged;
            textNumero.TextChanged += TextNumero_TextChanged;
            textTelefone.TextChanged += TextTelefone_TextChanged;
            textDescricao.TextChanged += TextDescricao_TextChanged;
            textEndereco.TextChanged += TextEndereco_TextChanged;
        }

        private void TextEndereco_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textoEstaVazio = string.IsNullOrEmpty(textEndereco.Text);
            if (textoEstaVazio)
            {
                textEndereco.Background = new SolidColorBrush(Colors.OrangeRed);
            }
            else
            {
                textEndereco.Background = new SolidColorBrush(Colors.White);
            }
        }

        private void TextDescricao_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textoEstaVazio = string.IsNullOrEmpty(textDescricao.Text);
            if (textoEstaVazio)
            {
                textDescricao.Background = new SolidColorBrush(Colors.OrangeRed);
            }
            else
            {
                textDescricao.Background = new SolidColorBrush(Colors.White);
            }
        }

        private void TextTelefone_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textoEstaVazio = string.IsNullOrEmpty(textTelefone.Text);
            if (textoEstaVazio)
            {
                textTelefone.Background = new SolidColorBrush(Colors.OrangeRed);
            }
            else
            {
                textTelefone.Background = new SolidColorBrush(Colors.White);
            }
        }

        private void TextNumero_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textoEstaVazio = string.IsNullOrEmpty(textNumero.Text);
            if (textoEstaVazio)
            {
                textNumero.Background = new SolidColorBrush(Colors.OrangeRed);
            }
            else
            {
                textNumero.Background = new SolidColorBrush(Colors.White);
            }
        }

        private void TextNome_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textoEstaVazio = string.IsNullOrEmpty(textNome.Text);
            if(textoEstaVazio)
            {
                textNome.Background = new SolidColorBrush(Colors.OrangeRed);
            }
            else
            {
                textNome.Background = new SolidColorBrush(Colors.White);
            }
        }

        private void Fechar(object sender, EventArgs e) =>
            Close();


    }
}
