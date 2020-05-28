using DAL.Context;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Repositories
{
    public class UOW : IUOW
    {
        private MovieDBContext Context;
        private IMovieRepository _movieRepository;
        private IGenreRepository _genreRepository;
        private IUserRepository _userRepository;
        public UOW(MovieDBContext context)
        {
            Context = context;
        }
        public IGenreRepository Genre {
            get {
                if (_genreRepository == null)
                    _genreRepository = new GenreRepository(Context);
                return _genreRepository;
            } }
        public IUserRepository User
        {
            get
            {
                if (_userRepository == null) //რა შემთხვევაში არ არის null?
                    _userRepository = new UserRepository(Context); //ავტომატურად დავწერე როგორც ფილმზე გეწერა და არ მახსოვს რას აკეთებს ზუსტად, ლექციას მოვუსმინე მარა დამავიწყდა :დ ანუ უბრალოდ დაზღვევაა რომ ნალ არასდროს წამოვა?
                return _userRepository;
            }
        }
        public IMovieRepository Movie
        {
            get
            {
                if (_movieRepository == null)
                    _movieRepository = new MovieReporitory(Context);
                return _movieRepository;
            }
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
