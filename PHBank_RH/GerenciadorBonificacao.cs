using PHBank_RH.Funcionarios;

namespace PHBank_RH
{
    public class GerenciadorBonificacao
    {
        public double TotalBonificacao { get; private set; }

        public void RegistrarBonificacao(Funcionario funcionario)
        {
            TotalBonificacao += funcionario.GetBonificacao();
        }



    }
}
