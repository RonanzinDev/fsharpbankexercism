open System.Collections.Generic

type Usuario =
    { Id: int
      Nome: string
      Email: string
      Balance: int }

let salvarUsuario = new Dictionary<int, Usuario>()

let criarUsuario (nome: string, email: string, balance: int) =
    let id = salvarUsuario.Values.Count + 1

    let novoUsuario =
        { Id = id
          Nome = nome
          Email = email
          Balance = balance }

    salvarUsuario.Add(id, novoUsuario)
    novoUsuario

let usuario1 =
    criarUsuario ("Gabriel", "g@gmail.com", 1000)

let usuario2 =
    criarUsuario ("Rafael", "r@gmail.com", 1000)

let pegarUsuario = salvarUsuario.Values |> Seq.toList

let buscarPorId id =
    if salvarUsuario.ContainsKey(id) then
        Some salvarUsuario.[id]
    else
        None


let validar (conta: Usuario, valor: int) = if conta.Balance < valor then 1 else 0


let tranferir (de: Usuario, para: Usuario, valor: int) =
    if validar (de, valor) = 1 then
        let user1 = de.Balance - valor
        let user2 = para.Balance + valor
        user1, user2
    else
        1, 2

    de, para

let resultado = tranferir (usuario1, usuario2, 100)
printfn "%A" resultado
