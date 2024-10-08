﻿using PrimalAPI.Models;
using PrimalAPI.Queries;

namespace PrimalAPI.Interfaces
{
    public interface ISizeRepository
    {
        Size? GetSizeById(int sizeId);
        Size? GetSizeByName(string name);
        ICollection<Size> GetSizes(PaginationQuery paginationQuery);
        int GetSizeCount();
        Size? GetSizeByPokemonId(int pokemonId);
        ICollection<Size> GetAllSizes();
    }
}
