using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ZydusFrontline.Entity.Logging;
using ZydusFrontline.Entity.MessageQueueModels;
using ZydusFrontline.Entity.Movies;
using ZydusFrontline.Interface.MessageQueue;
using ZydusFrontline.Interface.Movies;
using ZydusFrontline.Interface.Repository;
using ZydusFrontline.Interface.Services;
using ZydusFrontline.Repository.Movies;

namespace ZydusFrontline.Services.Movies
{
    public class MovieService : IMovieService
    {
        private IMovieRepository _movieRepository = null;
        private readonly IMessagePublisher _messagePublisher;
        private readonly TargetClient _targetClient;
        public MovieService(IMovieRepository movieRepository, IMessagePublisher messagePublisher, TargetClient targetClient)
        {
            _movieRepository = movieRepository;
            _messagePublisher = messagePublisher;
            this._targetClient = targetClient;
        }

        public Task<bool> Add(MovieEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(MovieEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            if (_movieRepository != null)
            {
                _movieRepository.Dispose();
            }
        }

        public async Task<List<MovieEntity>> Find(MovieEntity query)
        {
            var result = await _movieRepository.Entities(query);            
            return result.ToList();
        }

        public Task<bool> Update(MovieEntity entity)
        {
            throw new NotImplementedException();
        }

        /*Add your custom method*/
        public async Task<List<MovieEntityTest1>> CustomMethod1(MovieEntityTest1 query)
        {
            var result = await _movieRepository.CustomMethod(query);
            var movieMessage = result.FirstOrDefault();           
            #region Message Queue Functionality
            var customerCreated = new Customer()
            {
                Id = movieMessage.Id,
                Name = movieMessage.Title,
                Age = 50
            };

            var orderCreated = new Order()
            {
                Id = movieMessage.Id,
                ProductName = movieMessage.Title,
            };

            // Send this to the bus for the other services
            await _messagePublisher.PublishToQueue(customerCreated);
            await _messagePublisher.PublishToTopic(customerCreated);
            await _messagePublisher.PublishToTopic(orderCreated);
            #endregion
            return result.ToList();
        }

        public async Task<List<MovieEntityTest2>> CustomMethod2(MovieEntityTest1 query)
        {
            var result = await _movieRepository.CustomMethod2(query);
            var a = 0;
            var b = 2;
            var c = b / a;
            return result.ToList();
        }

        public async Task<string> CallTargetAsync()
        {
            return await _targetClient.SampleAsync();
        }
    }
}
