using Avalonia.Controls;
using Avalonia.Interactivity; 

namespace Argos;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public void AoClicarNoBotao(object sender, RoutedEventArgs args)
    {
        //1. CRIAÇÃO DA VARIÁVEL (Se a caixa de texto for nula, use "", que singifica texto vazio)
        string oQueFoiDigitado = CaixaDeTexto.Text ?? "";

        //Se o texto estiver vazio, não faz nada (retorna/sai da função)
        if (string.IsNullOrWhiteSpace(oQueFoiDigitado)) return;

        //2. FABRICAR um novo CheckBox
        //Em termos técnicos: Estou "Instanciando um objeto"
        CheckBox novaCaixa = new CheckBox();
        novaCaixa.Content = oQueFoiDigitado;

        //3. ADICIONAR na tela 
        // Estamos pegando nosso painel "ListaDeTarefas", acessando os filhos dele (Children) e adicionando o filho novo
        ListaDeTarefas.Children.Add(novaCaixa);

        //4. Limpar a caixa para a próxima
        CaixaDeTexto.Text = "";
    }
}