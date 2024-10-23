/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PokemonFightServiceService } from './pokemonFightService.service';

describe('Service: PokemonFightService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PokemonFightServiceService]
    });
  });

  it('should ...', inject([PokemonFightServiceService], (service: PokemonFightServiceService) => {
    expect(service).toBeTruthy();
  }));
});
