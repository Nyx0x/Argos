using Avalonia.Controls;
using Avalonia.Interactivity; 
using System.Collections.Generic;
using Argos.Models;


namespace Argos;

public partial class MainWindow : Window
{
    // Memória RAM do programa
    private List<Tarefa> _minhasTarefas = new List<Tarefa>();

    public MainWindow()
    {
        InitializeComponent();
    }

    public void AoClicarNoBotao(object sender, RoutedEventArgs args)
    {
        // Validar entrada
        string textoDigitado = CaixaDeTexto.Text ?? "";
        if (string.IsNullOrWhiteSpace(textoDigitado)) return;

        // Criar dado (Usando Model)
        //Em termos técnicos: "Instanciando um objeto/nova Tarefa"
        Tarefa novaTarefa = new Tarefa();
        novaTarefa.Descricao = textoDigitado;
        novaTarefa.Concluida = false;
        
        // Guardar na memória 
        // Adcionando a lista "secreta" _minhasTarefas
        _minhasTarefas.Add(novaTarefa);
        
        // Atualizar a interface (UI)
        // Criando checkbox visual para o usuário
        CheckBox checkboxVisual = new CheckBox();
        checkboxVisual.Content = novaTarefa.Descricao;
        checkboxVisual.IsChecked = novaTarefa.Concluida;

        // Adiciona na pilha visual (StackPanel)
        ListaDeTarefas.Children.Add(checkboxVisual);

        //4. Limpar a caixa para a próxima
        CaixaDeTexto.Text = "";
    }
}