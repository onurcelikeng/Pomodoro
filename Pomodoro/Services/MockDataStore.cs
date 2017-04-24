using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomodoro
{
    public class MockDataStore : IDataStore<Item>
    {
        bool isInitialized;
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();
            var _items = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Yemek yap", Description="This is a nice description"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Çocuğa süt ver", Description="This is a nice description"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Köpeği bahçeye çıkar", Description="This is a nice description"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sevgini göster", Description="This is a nice description"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Tuvaleti temizle", Description="This is a nice description"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Arabayı servise götür", Description="This is a nice description"},
            };

            foreach (Item item in _items)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var _item = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
