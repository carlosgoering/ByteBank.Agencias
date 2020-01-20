using ByteBank.Agencias.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ByteBank.Agencias
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ByteBankEntities _contextoBancoDeDados = new ByteBankEntities();
        private readonly ListBox ListaAgencias;
        public MainWindow()
        {
            InitializeComponent();
            ListaAgencias = new ListBox();
            AtualizarControles();
            AtualizarLista();
        }

        private void ListaAgencias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           if(sender != null)
            {
                var agenciaSelecionada = (Agencia)ListaAgencias.SelectedItem;
                textNumero.Text = agenciaSelecionada.Numero.ToString();
                textNome.Text = agenciaSelecionada.Nome;
                textTelefone.Text = agenciaSelecionada.Telefone;
                textDescricao.Text = agenciaSelecionada.Descricao;
                textEndereco.Text = agenciaSelecionada.Endereco;
            }
        }

        private void AtualizarLista()
        {
            ListaAgencias.Items.Clear();
            var agencias = _contextoBancoDeDados.Agencia.ToList();
            foreach (var agencia in agencias)
                ListaAgencias.Items.Add(agencia);
        }
        private void AtualizarControles()
        {
            ListaAgencias.SetValue(Grid.RowProperty, 0);
            MainGrid.Children.Add(ListaAgencias);
            ListaAgencias.SelectionChanged += ListaAgencias_SelectionChanged;
        }
        private void ButtonExcluir_Click(object sender, RoutedEventArgs e)
        {
            var confirmacao =
                MessageBox.Show("Você deseja realmente excluir este item?",
                "Confirmação",
                MessageBoxButton.YesNo);
            if(confirmacao == MessageBoxResult.Yes)
            {
                //excluir
            }
            else
            {
                //do nothing
            }
        }
        private void ButtonEditar_Click(object sender, RoutedEventArgs e)
        {
            var agenciaAtual = (Agencia)ListaAgencias.SelectedItem;
            var janelaEdicao = new EdicaoAgencia(agenciaAtual);
            var resultado = janelaEdicao.ShowDialog().Value;
            if (resultado)
            {

            }
            else
            {

            }
            
        }
    }
}
