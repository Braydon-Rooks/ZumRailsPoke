import { Component, inject } from '@angular/core';
import { PokemonFightServiceService } from '../pokemonFightService.service';

@Component({
  selector: 'app-results',
  standalone: true,
  imports: [],
  templateUrl: './results.component.html',
  styleUrl: './results.component.css'
})
export class ResultsComponent {
  fightService: PokemonFightServiceService = inject(PokemonFightServiceService);

}
