﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace ByteBank.Agencias
{
    public delegate bool ValidacaoEventHandler(string texto);
    public class ValidacaoTextBox : TextBox
    {
        private ValidacaoEventHandler _validacao;
        public event ValidacaoEventHandler Validacao
        {
            add
            {
                _validacao += value;
                _validacao(Text);
            }
            remove
            {
                _validacao -= value;
            }
        }
        public ValidacaoTextBox()
        {
            TextChanged += validacaoTextBox_TextChanged;
        }
        public void validacaoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            OnValidacao();
        }
        private void OnValidacao()
        {
            if (_validacao != null)
            {
                var listaValidacao =_validacao.GetInvocationList();
                var ehValido = true;
                foreach(ValidacaoEventHandler validacao in listaValidacao)
                {
                    if (validacao(Text) == false)
                    {
                        ehValido = false;
                        break;
                    }
                }
                Background = ehValido
                ? new SolidColorBrush(Colors.White)
                : new SolidColorBrush(Colors.OrangeRed);
            }
        }
    }

}