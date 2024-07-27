1) Os princípios do SOLID contêm 5 significados. Cada sigla do SOLID tem um significado de boa prática que, ao ser aplicado, facilita a manutenção do código, a reutilização do código, entre outras melhorias.

    S -> Single Responsibility Principle: Esse princípio tem como base que uma classe tenha apenas uma responsabilidade, ou seja, deve realizar apenas uma tarefa específica.
    Exemplo: Em .Net eu poderia ter uma classe Qualification -> essa classe vai ter apenas tarefas relacionadas com qualificação caso tenha mais de uma responsabilidade o ideal é criar outra classe específica.

    O -> Open/Closed Principle: Esse princípio tem como base que objetos ou entidades devem estar abertos para extensão e fechados para modificação. Quando se precisa adicionar algo no software, devemos extender e não modificar. 
    Exemplo: No ambiente .net podemos ter uma classe que seria ContractCLT que tem uma função chamada Wage() e outra que seria Intern que tem a função de AidGrand() e temos uma classe de Payroll onde temo um if para calcular o contractClt e outra para calcular o Intern se tivessemos outro poderiamos colocar outro if porém estaria quebrando o princípio, o ideal é criar uma interface IRemunerable que tem um método Remunerable(); as outras classes vão implementar essa interface assim na classe Payroll teremos um método Calculate(IRemunerable contract).

    L -> Liskov Substitution Principle: Objetos do tipo base devem ser substituídos por uma outra instância de um subtipo dessa base e, com essa alteração, não deve comprometer o funcionamento do programa. 
    Exemplo: No .Net eu tenho uma classe Person que é estendida por Employee e, nessa classe Person, há um método chamado GetName(). Já no meu main, tenho uma função PrintName(Person p) {p.GetName()}. Segundo o princípio LSP, eu conseguiria passar tanto um objeto do tipo Person quanto do tipo Employee no método.

    I -> Interface Segregation Principle: Esse princípio tem como objetivo pegar interfaces que possuem muitas responsabilidades e com métodos não coesos e dividi-las em interfaces específicas e menores. 
    Exemplo: No .Net Vamos supor que temos uma interface IAnimal que tem os métodos de ToHunt, Fly e Swim. Porém, a classe Alligator não deveria ter o método Fly e nem Swim, por isso podemos criar uma interface ILandAnimal que extende IAnimal, e o Alligator vai herdar de ILandAnimal.

    D -> Dependency Inversion Principle: Esse princípio fala que devemos depender de abstrações e não de implementações. 
    Exemplo: No .Net Temos uma classe User e, em seu construtor, ela cria um novo endereço para esse usuário, ou seja, ela dá um new Address(). Aqui temos um alto nível de acoplamento. O ideal seria passar como parâmetro do construtor um objeto do tipo Address, assim você retira o acoplamento.

2) Layered Architecture, Clean Architecture, Microservices, Event-Driven Architecture, Service-Oriented Architecture, MVC, Repository, Unit Of Work e CQRS.

    Padrão Repository: Esse padrão ele tem a função de servir como uma barreira de controle entre a aplicação e os dados Ex: Temos uma classe Document onde tem 2 atributos, Title e Status, ou seja, isso segundo o DDD é chamado de Aggregate onde ele é a unica coisa que é persistida no repository. Então poderiamos criar um IDocumentRepository com os metodos de Save(), Delete(), Get(), List(). Ou seja ele faz com que qualquer alteração feita no Document vai passar pela regra de negocio e com isso preservando o Domain Model.

    CQRS: Esse outro padrão tem como objetivo utilizar um banco para escrita e um banco para leitura. A ideia é ter um banco para atualizar dados que no caso são feitos por comandos e o outro é para leitura de dados ou seja consultas. Esse padrão ele tem o beneficio de não sobrecarregar o banco de dados com leitura e escrita, quando você tem um banco só para leitura e outro só para escrita você consegue melhorar a perfomarce.

3) Quando você junta a regra de negócio e a lógica de apresentação você estará formando um forte acoplamento, dificultando os testes e  também fazendo com que não tenha uma evolução na aplicação sem o forte acoplamento. Isso pode ser alcançado utilizando algum padrão de projeto por exemplo o MVC -> tendo o Model: Tem a regra de negócios, tem o View: Responsável pela interface do usuário, e por ultimo o Controller: Relaciona-se com a Model e a View.