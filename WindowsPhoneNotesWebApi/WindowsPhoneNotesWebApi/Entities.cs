using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WindowsPhoneNotesWebApi
{
    public class Entities
    {
        public bool Authenticate(string login, string password)
        {
            using (NotesAppEntities context = new NotesAppEntities())
            {
                try
                {
                    var entity = context.Member.FirstOrDefault(x => x.Email == login && x.Password == password);

                    if (entity != null)
                    {
                        return true;
                    }
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return false;
        }

        public Member GetMember(string login, string password)
        {
            using (NotesAppEntities context = new NotesAppEntities())
            {
                try
                {
                    var entity = context.Member.FirstOrDefault(x => x.Email == login && x.Password == password);

                    if (entity != null)
                    {
                        return new Member()
                        {
                            Id = entity.Id,
                            Email = entity.Email,
                            FirstName = entity.FirstName,
                            LastName = entity.LastName,
                            Note = entity.Note.ToList()
                        };
                    }
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            return null;
            
        }

        public List<Note> GetNotes(string login, string password)
        {
            using (NotesAppEntities context = new NotesAppEntities())
            {
                try
                {
                    var entity = context.Member.FirstOrDefault(x => x.Email == login && x.Password == password);

                    if (entity != null)
                    {
                        List<Note> notes = entity.Note.ToList();

                        return notes;
                    }
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            return null;

        }

        public bool CreateNote(string login, string password, string title)
        {
            using (NotesAppEntities context = new NotesAppEntities())
            {
                try
                {
                    var entity = context.Member.FirstOrDefault(x => x.Email == login && x.Password == password);

                    if (entity != null)
                    {
                        entity.Note.Add(new Note()
                        {
                            Title = title
                        });

                        context.SaveChanges();
                        return true;
                    }
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return false;

        }

        public bool UpdateNote(string login, string password, string title, string content)
        {
            using (NotesAppEntities context = new NotesAppEntities())
            {
                try
                {
                    var entity = context.Member.FirstOrDefault(x => x.Email == login && x.Password == password);

                    if (entity != null)
                    {
                        var noteEntity = entity.Note.FirstOrDefault(x => x.Title == title);

                        noteEntity.Text = content;

                        context.SaveChanges();
                        return true;
                    }
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return false;

        }

        public bool DeleteNote(string login, string password, string title)
        {
            using (NotesAppEntities context = new NotesAppEntities())
            {
                try
                {
                    var entity = context.Member.FirstOrDefault(x => x.Email == login && x.Password == password);

                    if (entity != null)
                    {
                        var noteEntity = entity.Note.FirstOrDefault(x => x.Title == title);

                        context.Note.Remove(noteEntity);
                        context.SaveChanges();
                        return true;
                    }
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return false;

        }
    }
}