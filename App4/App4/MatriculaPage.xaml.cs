using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App4.Modelos;


namespace App4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatriculaPage : ContentPage
    {
        Disciplina[] disciplinas = new Disciplina[4]
       {
            new Disciplina("Calculo 1",1,1),
            new Disciplina("Física",2,2),
            new Disciplina("Programação",3,3),
            new Disciplina("Calculo 2",4,4)
       };

        public MatriculaPage()
        {
            InitializeComponent();
            // para todos os alunos da lista
            foreach (Aluno aluno in Listas.Alunos)
            {
                // adicionar um elemento na caixa de seleção
                Picker.Items.Add(aluno.Matricula + " - " + aluno.Nome);
            }

            foreach (Disciplina disciplina in disciplinas)
            {
                Picker2.Items.Add(disciplina.Professor + " - " + disciplina.Nome);
            }



        }

        void OnButtonClicked(object sender, EventArgs args)
        {
            if (Picker.SelectedIndex >= 0 &&
                Picker2.SelectedIndex>=0)
            {
                if (Entry.Text != null)
                {
                    Aluno aluno = Listas.Alunos.ElementAt(Picker.SelectedIndex);
                    Label.Text = aluno.Matricular(disciplinas[Picker2.SelectedIndex], int.Parse(Entry.Text)).ToString();
                }
                else
                {
                    Aluno aluno = Listas.Alunos.ElementAt(Picker.SelectedIndex);
                    Label.Text = aluno.Matricular(disciplinas[Picker2.SelectedIndex]).ToString();

                }

            }
            


        }
    }
}