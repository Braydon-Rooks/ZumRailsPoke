import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { PokemonFightServiceService } from '../pokemonFightService.service';

@Component({
  selector: 'app-the-form',
  standalone: true,
  imports: [
    ReactiveFormsModule
  ],
  templateUrl: './the-form.component.html',
  styleUrl: './the-form.component.css'
})
export class TheFormComponent {
  fightService: PokemonFightServiceService = inject(PokemonFightServiceService);
  sortByOptions: Array<string> = ["Name","Id","Ties","Wins","Losses"];
  sortDircOptions: Array<string> = ["Asc", "Desc", ""];
  
  pokemonFilterForm = new FormGroup({
    sortBy: new FormControl(''),
    sortDirection: new FormControl(''),
  });

  getFightResults(){
    this.fightService.getResults(this.pokemonFilterForm.value.sortBy ?? '', this.pokemonFilterForm.value.sortDirection ?? '')
}
}
