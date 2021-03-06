using System.Collections.Generic;
using System.Linq;
using dwCheckApi.DTO.ViewModels;
using dwCheckApi.Entities;

namespace dwCheckApi.DTO.Helpers
{
    public static class CharacterViewModelHelpers
    {
        public static CharacterViewModel ConvertToViewModel (Character dbModel, IEnumerable<string> books = null)
        {
            var viewModel = new CharacterViewModel
            {
                CharacterName = dbModel.CharacterName
            };

            if (books != null)
            {
                viewModel.Books.AddRange(books);
            }
            else
            {
                foreach (var bc in dbModel.BookCharacter)
                {
                    viewModel.Books.Add(bc.Book.BookName ?? string.Empty);
                }
            }

            return viewModel;
        }

        public static List<CharacterViewModel> ConvertToViewModels(List<Character> dbModels)
        {
            return dbModels.Select(ch => ConvertToViewModel(ch)).ToList();
        }
    }
}