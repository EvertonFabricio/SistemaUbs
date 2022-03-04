# SistemaUbs

inicia informando o programa quantos leitos tem disponivel. A cada internação o numero de leitos diminui, até chegar a zero, e a cada alta o numero de leitos aumenta até o limite informado no inicio.

abre o menu, oferecendo as opçoes pro usuario. 

Escolhendo a opção 1, o sistema pergunta qual o ano de nascimento da pessoa, pra saber se gera senha preferencial ou senha normal. A senha é gerada aleatoriamente e armazenada na fila de senha preferencial ou na fila de senha comum.

Escolhendo a opção 2, chama a primeira senha, respeitando sempre 2 preferenciais pra 1 comum. Se não tiver senha preferencial, ele chama apenas da fila de senha comum.
Quando a senha é chamada, existe a opção de vc cadastrar o paciente, ou descartar a senha chamada no caso do paciente ter desistido do atendimento. 
Optando por cadastrar o paciente, será solicitado informaçoes pessoais como nome, cpf e ano de nascimento. Assim como será solicitado informaçoes de triagem, como quantidade de dias de sintomas, temperatura, se possui comorbidades, e saturação de oxigênio. Baseado nessas informaçoes, o sistema determina se paciente precisa fazer o exame ou não. Caso não seja, será informado que pode liberar o paciente. Caso seja, o paciente sera inserido na fila para exame.

escolhendo a opção 3, chama o paciente e informa se o exame dele deu positivo ou negativo. Caso seja negativo, sera informado que pode liberar o paciente. Caso positivo, o sistema vai analizar as informaçoes da triagem pra determinar se paciente pode apenas cumprir a quarentena em casa, ou se deve aguardar na fila de internação para ser internado.

*toda vez que uma opçao é finalizada e volta pro menu, é feito a leitura da quantidade de leitos vagos, e caso tenha leitos vagos, automaticamente o primeiro da fila aguardando internação já é inserido na internação.

Opção 4 mostra na tela todas as pessoas cadastradas que ainda estão aguardando exame.

Opção 5 mostra na tela todas as pessoas que estão aguardando para ser internada.

opçao 6 mostra todas as pessoas internadas.

opção 7 era pra dar alta pro paciente. Mas não foi implementado.

opção 8 era pra listar todas as pessoas que foram liberadas, desde a pessoa que foi liberada na triagem até a pessoa que foi liberada por alta. Todo mundo que foi cadastrado seria relacionado nessa lista. Porém não foi implementado.
