open System.Collections.Generic

type Usuario =
{ Id: int
Nome: string
Descricao: string }

let SalvarUsuario = new Dictionary<int, Usuario>()

let PegarUsuario = SalvarUsuario.Values |> Seq.toList

let PegarUsuarioPorId id =
if SalvarUsuario.ContainsKey(id) then
Some SalvarUsuario.[id]
else
None

let CriarUsuario (nome: string, descricao: string) =
let id = SalvarUsuario.Values.Count + 1

    let novoUsuario =
        { Id = id
          Nome = nome
          Descricao = descricao }

    SalvarUsuario.Add(id, novoUsuario)
    novoUsuario

let AtualizarUsuarioPorId usuarioId usarioPraAtualizar =
if SalvarUsuario.ContainsKey(usuarioId) then
let atualizarUsuario =
{ Id = usuarioId
Nome = usarioPraAtualizar.Nome
Descricao = usarioPraAtualizar.Descricao }

        SalvarUsuario.[usuarioId] <- atualizarUsuario

let deletarUsuario usuarioId =
SalvarUsuario.Remove(usuarioId) |> ignore

CriarUsuario("Gabriel", "É FODA") |> printf "%A"
