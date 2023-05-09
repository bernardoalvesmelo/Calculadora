namespace Calculadora
{
    public partial class Calculadora : Form
    {
        private string numero1;
        private string numero2;
        private string operacao;
        private string estado;
        public Calculadora()
        {
            InitializeComponent();
            Resetar();
            this.numero1 = "";
        }

        private void Resetar()
        {
            this.numero2 = "";
            this.operacao = "";
            this.estado = "numero1";
            textBoxExibicao.Text = "";
        }

        private void ObterTecla(string numero)
        {
            if (this.estado == "finalizado")
            {
                Resetar();
                this.numero1 = "";
            }
            switch (this.estado)
            {
                case "numero1":
                    this.numero1 += numero;
                    break;
                case "numero2":
                    this.numero2 += numero;
                    break;
            }
            AtualizarTextBox();
        }

        private void ObterOperacao(string operacao)
        {
            if (this.estado == "finalizado")
            {
                Resetar();
            }
            if (this.numero1 == "")
            {
                return;
            }
            switch (this.estado)
            {
                case "numero1":
                    this.operacao = operacao;
                    this.estado = "numero2";
                    break;
                case "numero2":
                    if (numero2 == "")
                    {
                        this.operacao = operacao;
                        AtualizarTextBox();
                        return;
                    }
                    try
                    {
                        this.numero1 = ExecutarOperacao();
                        this.numero2 = "";
                        this.operacao = operacao;
                        this.estado = "numero2";
                    }
                    catch (Exception)
                    {
                        Resetar();
                        textBoxExibicao.Text = "ERRO";
                        this.estado = "finalizado";
                        this.numero1 = "";
                        return;
                    }
                    break;
            }
            AtualizarTextBox();
        }

        private void FinalizarOperacao()
        {
            if (this.estado == "finalizado")
            {
                Resetar();
            }
            else if (this.estado == "numero2")
            {
                if (numero2 == "")
                {
                    this.estado = "numero1";
                    this.operacao = "";
                    return;
                }
                try
                {
                    this.numero1 = ExecutarOperacao();
                    textBoxExibicao.Text = this.numero1;
                }
                catch (Exception)
                {
                    textBoxExibicao.Text = "ERRO";
                    this.numero1 = "";
                }
                finally
                {
                    this.estado = "finalizado";
                }
            }
        }

        public string ExecutarOperacao()
        {
            if (numero1.Contains(","))
            {
                if (numero1.Split(",")[1].Length == 0)
                {
                    numero1 = numero1.Split(",")[0];
                }
            }
            if (numero2.Contains(","))
            {
                if (numero2.Split(",")[1].Length == 0)
                {
                    numero2 = numero2.Split(",")[0];
                }
            }
            double n1 = Convert.ToDouble(numero1);
            double n2 = Convert.ToDouble(numero2);
            string resultado = "";
            switch (this.operacao)
            {
                case "+":
                    resultado = (n1 + n2) + "";
                    break;
                case "-":
                    resultado = (n1 - n2) + "";
                    break;
                case "*":
                    resultado = (n1 * n2) + "";
                    break;
                case "/":
                    if (n2 == 0)
                    {
                        throw new DivideByZeroException(); 
                    }
                    resultado = (n1 / n2) + "";
                    break;
            }
            return resultado;
        }

        private void AtualizarTextBox()
        {
            textBoxExibicao.Text = $"{numero1} {this.operacao} {numero2}";
        }

        private void btnN1_Click(object sender, EventArgs e)
        {
            ObterTecla("1");
        }

        private void btnN2_Click(object sender, EventArgs e)
        {
            ObterTecla("2");
        }

        private void btnN3_Click(object sender, EventArgs e)
        {
            ObterTecla("3");
        }

        private void btnN4_Click(object sender, EventArgs e)
        {
            ObterTecla("4");
        }

        private void btnN5_Click(object sender, EventArgs e)
        {
            ObterTecla("5");
        }
        private void button6_Click(object sender, EventArgs e)
        {
            ObterTecla("6");
        }
        private void b7_Click(object sender, EventArgs e)
        {
            ObterTecla("7");
        }
        private void button8_Click(object sender, EventArgs e)
        {
            ObterTecla("8");
        }
        private void btn9_Click(object sender, EventArgs e)
        {
            ObterTecla("9");
        }
        private void btn0_Click(object sender, EventArgs e)
        {
            ObterTecla("0");
        }
        private void btnMais_Click(object sender, EventArgs e)
        {
            ObterOperacao("+");
        }

        private void btnMenos_Click(object sender, EventArgs e)
        {
            ObterOperacao("-");
        }

        private void btnVezes_Click(object sender, EventArgs e)
        {
            ObterOperacao("*");
        }

        private void btnDivisao_Click(object sender, EventArgs e)
        {
            ObterOperacao("/");
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            FinalizarOperacao();
        }

        private void btnPonto_Click(object sender, EventArgs e)
        {
            if (this.estado == "finalizado")
            {
                Resetar();
            }
            switch (this.estado)
            {
                case "numero1":
                    if(this.numero1 == "" || this.numero1.Contains(","))
                    {
                        return;
                    }
                    this.numero1 += ",";
                    break;
                case "numero2":
                    if (this.numero2 == "" || this.numero2.Contains(","))
                    {
                        return;
                    }
                    this.numero2 += ",";
                    break;
            }
            AtualizarTextBox();
        }
    }
}