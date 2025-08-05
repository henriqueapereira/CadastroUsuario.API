using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CadastroUsuario.API.Validations;

public class CpfValidationAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        var cpf = value as string;

        if (string.IsNullOrEmpty(cpf))
            return false;

        cpf = Regex.Replace(cpf, "[^0-9]", "");

        if (cpf.Length != 11 || cpf.Distinct().Count() == 1)
            return false;

        int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        string tempCpf = cpf.Substring(0, 9);
        int soma = 0;

        for (int i = 0; i < 9; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

        int resto = soma % 11;
        if (resto < 2) resto = 0;
        else resto = 11 - resto;

        tempCpf += resto;
        soma = 0;

        for (int i = 0; i < 10; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

        resto = soma % 11;
        if (resto < 2) resto = 0;
        else resto = 11 - resto;

        return cpf.EndsWith(resto.ToString());
    }
}
