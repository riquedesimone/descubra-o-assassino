import { Arma } from "./arma.model";
import { Suspeito } from "./suspeito.model";
import { Local } from "./local.model";

export interface Listas 
{
    Armas: Arma[],
    Suspeitos: Suspeito[],
    Locais: Local[]
}