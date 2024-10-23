import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FightResult } from './fightResult';

@Injectable({
    providedIn: 'root'
  })
export class PokemonFightServiceService {
    baseUri = "http://localhost:5094";

    fightResults: Array<FightResult> = [];
    errors: Array<object> = [];
    constructor(private http: HttpClient) { }
    getResults(sortBy: string, sortDirection: string) {
        console.log(`Sort by: ${sortBy}, Direction: ${sortDirection}`);
        this.http.get(this.baseUri+"/pokemon/tournament/statistics",{params:{sortBy, sortDirection}})
         .subscribe({
            next: res => this.fightResults = Object.assign(new Array<FightResult>, res),
            error: err => this.errors = err.error.errors
        });
    }
}


