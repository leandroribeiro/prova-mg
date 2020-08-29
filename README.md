[9:37 PM, 8/28/2020] Glauco: Vamos lá: nesse link, tem um bootstrap com um front end muito completo (html5, js...)

https://we.tl/t-9xRU0VmXXc

Eu criei um DB no Azure que contem apenas uma tabela.

Servidor: ilm.database.windows.net
Database: Teste
Usuario: usr_teste
Senha: X9Xs5GaB

Para logar via SSMS voce precisa só alterar o database inicial para "Teste", pois senao vai dar erro dizendo que esse usuario nao tem permissao para acessar a base "master".

A ideia é voce importar o bootstrap para dentro de um projeto no Visual Studio e a partir dele, construir algumas coisas, utiliando o código/pagina do bootstrap que julgar melhor:

1) Uma pagina de login - para isso, voce terá que criar a tabela de usuarios no SQL, bem como o acesso a ela (view, store procedure, entity...).

2) Uma vez logado, um combo que lista as UFs distintas contidas na tabela "tb_tipo_municipio". Ao ser selecionada uma UF, a pagina deve carregar os municipios da UF selecionada, paginados de 10 em 10.

3) Após o carregamento, o nome do municipio deve ser clicável se o código do municipio (tipo_municipio_cod) na tabela "tb_tipo_municipio" for divisivel por 3. Ao clicar, o usuario tem que poder editar o nome do municipio clicado e ao "salvar", já alterar a tela.

A forma como voce fará o acesso ao banco de dados, a separação das camadas no código são fatores de análise. O acesso aos dados pode ser feito por entity ou utilizando stored procedures ou da maneira que achar melhor, tanto para buscar quanto para atualizar dados. Sobre a forma como voce fará o frontend (recarregar pagina, usar ajax...) tb fica a seu criterio.

A ideia é realmente entender como voce programa MVC, como voce pensa camadas e seu conhecimento com frontend.

 Se tiver qualquer duvida sobre a tarefa, pode me chamar
[9:38 PM, 8/28/2020] Glauco: PS: tem uma tabela de usuarios la ja (corrigindo acima). Pode usar ela. Ta bem simples. Voce pode editar, deletar, ou inserir infos em qualquer tabela do SQL, bem como criar objetos (procedures, views...)