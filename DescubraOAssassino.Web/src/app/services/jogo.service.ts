import { Injectable} from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { Listas } from '../models/listas.model';
import { TeoriaRequest } from '../models/teoria-request.model';
import { TeoriaResponse } from '../models/teoria-response.model';
import { JogoResponse } from '../models/jogo-response.model';

@Injectable()
export class JogoService {
    private baseUrl :string;

    constructor(private http: HttpClient) {
        this.baseUrl = `${environment.baseUrl}`;
    }

    public novoJogo():Observable<JogoResponse>
    {
        return this.http.get<JogoResponse>(`${this.baseUrl}crime/new`);    
    }
    
    public getListas():Observable<Listas>
    {
        return this.http.get<Listas>(`${this.baseUrl}crime/all`);
    }

    public checkTeoria(teoriaRequest: TeoriaRequest):Observable<TeoriaResponse>
    {
        return this.http.get<TeoriaResponse>(`${this.baseUrl}crime/check?id=${teoriaRequest.id}&suspeito=${teoriaRequest.suspeito}&local=${teoriaRequest.local}&arma=${teoriaRequest.arma}`);
    }
}