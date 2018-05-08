import { Component, OnInit } from '@angular/core';
import { Suspeito } from '../models/suspeito.model';
import { Arma } from '../models/arma.model';
import { Local } from '../models/local.model';
import { JogoService } from '../services/jogo.service';
import { isNullOrUndefined } from 'util';

@Component({
  selector: 'app-descubra',
  templateUrl: './descubra.component.html',
  styleUrls: ['./descubra.component.css']
})
export class DescubraComponent implements OnInit {
  
  status = -1;
  message: string;

  loading = false;
  jogoId: string;
  suspeitos: Suspeito[];
  armas: Arma[];
  locais: Local[];

  currentSuspeito: Suspeito;
  currentArma: Arma;
  currentLocal: Local;

  constructor(private jogoService:JogoService) {
      
  }

  ngOnInit() {
    this.novoJogo();
    this.jogoService.getListas().subscribe(result => {
      this.suspeitos = result.Suspeitos;
      this.armas = result.Armas;
      this.locais = result.Locais;
    });
  }

  setSuspeito(item:Suspeito){
    this.message = "";
    this.currentSuspeito = item;
  }

  setArma(item:Arma){
    this.message = "";
    this.currentArma = item;
  }

  setLocal(item:Local){
    this.message = "";
    this.currentLocal = item;
  }

  checarTeoria()
  {
    this.loading = true;
    this.jogoService.checkTeoria({
      id: this.jogoId,
      arma: this.currentArma.Id,
      suspeito: this.currentSuspeito.Id,
      local: this.currentLocal.Id}).subscribe(response => {
        this.loading = false;
        this.status = response.SituacaoJogo;
        this.message = response.Message;
      });
  }

  novoJogo() 
  {
    this.currentSuspeito = null;
    this.currentArma = null;
    this.currentLocal = null;
    this.status = -1;
    this.message = "";
    this.jogoService.novoJogo().subscribe(response => this.jogoId = response.Id);
  }

  IsValid()
  {
    return this.loading || isNullOrUndefined(this.currentSuspeito) || isNullOrUndefined(this.currentArma) || isNullOrUndefined(this.currentLocal);
  }
}
