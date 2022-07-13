//VARIÁVEIS
var nomeInput = document.querySelector("#nome");
var cpfInput = document.querySelector("#cpf");
var emailInput = document.querySelector("#email");
var mailErrorInput = document.querySelector("#mailError");
var loginInput = document.querySelector("#login");
var senhaInput = document.querySelector("#senha");
var senhaRegistroInput = document.querySelector("#senhaRegistro");
var senhaErrorInput = document.querySelector("#senhaError");
var cepInput = document.querySelector("#cep");
var enderecoInput = document.querySelector("#endereco");
var numero_enderecoInput = document.querySelector("#numero_endereco");
var complementoInput = document.querySelector("#complemento");
var bairroInput = document.querySelector("#bairro");
var cidadeInput = document.querySelector("#cidade");
var estadoInput = document.querySelector("#estado");

//TRANSFORMANDO TODAS PARA MAIÚSUCLA/MINÚSCULA ENQUANTO É DIGITADA
document.getElementById('nome').addEventListener('keyup', (ev) => {
    var nomeInput = ev.target;
    nomeInput.value = nomeInput.value.toUpperCase();
});

document.getElementById('email').addEventListener('keyup', (ev) => {
    var emailInput = ev.target;
    emailInput.value = emailInput.value.toLowerCase();
});

document.getElementById('login').addEventListener('keyup', (ev) => {
    var loginInput = ev.target;
    loginInput.value = loginInput.value.toLowerCase();
});

document.getElementById('complemento').addEventListener('keyup', (ev) => {
    var complementoInput = ev.target;
    complementoInput.value = complementoInput.value.toUpperCase();
});

//VALIDANDO APENAS LETRAS/NÚMEROS NOS CAMPOS
nomeInput.addEventListener("keypress", function (e) {
    if (!checkChar(e)) {
        e.preventDefault();
    }
});

cepInput.addEventListener("keypress", function (e) {
    if (!checkNumber(e)) {
        e.preventDefault();
    }
});

//APENAS LETRAS
function checkChar(e) {
    var char = String.fromCharCode(e.keyCode);
    var pattern = "[a-zA-Z]";

    if (char.match(pattern)) {
        return true;
    }
}

//APENAS NÚMEROS
function checkNumber(e) {
    var char = String.fromCharCode(e.keyCode);
    var pattern = "[0-9]";

    if (char.match(pattern)) {
        return true;
    }
}

//VALIDANDO EMAIL
function validarEmail() {
    if (!emailInput.checkValidity()) {
        mailErrorInput.innerHTML = "E-mail inválido";
    }
}

function redefinirMsg() {
    if (mailErrorInput.innerHTML == "E-mail inválido") {
        mailErrorInput.innerHTML = "";
    }
}

//VALIDANDO SENHA E MOSTRANDO A FORÇA DELA
function validarSenhaForca() {
    var senha = document.getElementById('senhaRegistro').value;
    var forca = 0;

    if (senha.length >= 8) {

        senhaErrorInput.innerHTML = "";

        if ((senha.length >= 8) && (senha.length <= 10)) {
            forca += 10;
        } else if (senha.length > 10) {
            forca += 25;
        }

        if ((senha.length >= 8) && (senha.match(/[a-z]+/))) {
            forca += 10;
        }

        if ((senha.length >= 10) && (senha.match(/[A-Z]+/))) {
            forca += 20;
        }

        if ((senha.length >= 10) && (senha.match(/[@#$%&;*]/))) {
            forca += 25;
        }

        if (senha.match(/([1-9]+)\1{1,}/)) {
            forca += -25;
        }

        mostrarForca(forca);
    }
    else {
        senhaErrorInput.innerHTML = "Senha Inválida"
    }
}

function mostrarForca(forca) {

    if (forca < 30) {
        document.getElementById("erroSenhaForca").innerHTML = "Força:" + '<div class="progress"><div class="progress-bar bg-danger" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div></div>';
    } else if ((forca >= 30) && (forca < 50)) {
        document.getElementById("erroSenhaForca").innerHTML = "Força:" + '<div class="progress"><div class="progress-bar bg-warning" role="progressbar" style="width: 50%" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100"></div></div>';
    } else if ((forca >= 50) && (forca < 70)) {
        document.getElementById("erroSenhaForca").innerHTML = "Força:" + '<div class="progress"><div class="progress-bar bg-info" role="progressbar" style="width: 75%" aria-valuenow="75" aria-valuemin="0" aria-valuemax="100"></div></div>';
    } else if ((forca >= 70) && (forca < 100)) {
        document.getElementById("erroSenhaForca").innerHTML = "Força:" + '<div class="progress"><div class="progress-bar bg-success" role="progressbar" style="width: 100%" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100"></div></div>';
    }
}

function mostrarOcultarSenha() {

    var senha = document.getElementById("senhaRegistro");

    if (senha.type == "password") {
        senha.type = "text";

    } else {
        senha.type = "password";
    }
}

//VALIDAÇÃO DE CEP - VIA CEP
function limpa_formulário_cep() {
    //Limpa valores do formulário de cep.
    document.getElementById('endereco').value = ("");
    document.getElementById('complemento').value = ("");
    document.getElementById('bairro').value = ("");
    document.getElementById('cidade').value = ("");
    document.getElementById('estado').value = ("");
}

function meu_callback(conteudo) {
    if (!("erro" in conteudo)) {
        //Atualiza os campos com os valores.
        document.getElementById('endereco').value = (conteudo.logradouro).toUpperCase();
        document.getElementById('bairro').value = (conteudo.bairro).toUpperCase();
        document.getElementById('cidade').value = (conteudo.localidade).toUpperCase();
        document.getElementById('estado').value = (conteudo.uf).toUpperCase();
    } //end if.
    else {
        //CEP não Encontrado.
        limpa_formulário_cep();
        alert("CEP não encontrado.");
    }
}

function pesquisacep(valor) {

    //Nova variável "cep" somente com dígitos.
    var cep = valor.replace(/\D/g, '');

    //Verifica se campo cep possui valor informado.
    if (cep != "") {

        //Expressão regular para validar o CEP.
        var validacep = /^[0-9]{8}$/;

        //Valida o formato do CEP.
        if (validacep.test(cep)) {

            //Preenche os campos com "..." enquanto consulta webservice.
            document.getElementById('endereco').value = "...";
            document.getElementById('bairro').value = "...";
            document.getElementById('cidade').value = "...";
            document.getElementById('estado').value = "...";

            //Cria um elemento javascript.
            var script = document.createElement('script');

            //Sincroniza com o callback.
            script.src = 'https://viacep.com.br/ws/' + cep + '/json/?callback=meu_callback';

            //Insere script no documento e carrega o conteúdo.
            document.body.appendChild(script);

        } //end if.
        else {
            //cep é inválido.
            limpa_formulário_cep();
            alert("Formato de CEP inválido.");
        }
    } //end if.
    else {
        //cep sem valor, limpa formulário.
        limpa_formulário_cep();
    }
};

