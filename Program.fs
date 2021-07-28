open System
open System.Collections.Generic

type Usuario =
    { Id: int
      Nome: string
      Email: string
      Balance: int }

let usuariosSalvos = new Dictionary<int, Usuario>()

let criarUsuario (nome: string, email: string, balance: int) =
    let id = usuariosSalvos.Values.Count + 1

    let novoUsuario =
        { Id = id
          Nome = nome
          Email = email
          Balance = balance }

    usuariosSalvos.Add(id, novoUsuario)
    novoUsuario

let usuario1 =
    criarUsuario ("Gabriel", "g@gmail.com", 1000)

let usuario2 =
    criarUsuario ("Rafael", "r@gmail.com", 1000)

let usuarios = usuariosSalvos.Values |> Seq.toList

let existeUsuarioComId id =
    usuarios |> List.exists (fun x -> x.Id = id)

let buscarPorId id =
    match (existeUsuarioComId id) with
    | false -> None
    | _ -> Some usuariosSalvos.[id]

let temSaldoSuficiente (conta: Usuario) (valor: int) : bool = conta.Balance >= valor

let tranferir (remetente: Usuario) (para: Usuario) (valor: int) : (int * int) option =
    match (temSaldoSuficiente remetente valor) with
    | false -> None
    | _ -> Some(remetente.Balance - valor, para.Balance + valor)

[<EntryPoint>]
let main argv =
    tranferir usuario1 usuario2 100
    |> Option.defaultValue (0, 0)
    |> printfn "%A"

    0 // return an integer exit code

    0 // return an integer exit code
