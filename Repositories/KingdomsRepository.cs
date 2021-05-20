using System.Collections.Generic;
using System.Data;
using cs_knights_tale.Models;
using Dapper;

namespace cs_knights_tale.Repositories
{
    public class KingdomsRepository : IRepository<Kingdom>
    {
        private readonly IDbConnection _db;

        public KingdomsRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<Kingdom> GetAll()
        {
            string sql = "SELECT * FROM kingdoms";
            return _db.Query<Kingdom>(sql);
        }

        public Kingdom GetById(int id)
        {
            // Dapper uses '@' to indicate a variable that can be safelt injected in the Query arguments
            string sql = "SELECT * FROM kingdoms WHERE id = @id";
            // Query first or default returns a single item or 'null'
            return _db.QueryFirstOrDefault<Kingdom>(sql, new { id });
        }

        public Kingdom Create(Kingdom newKingdom)
        {
            string sql = @"
            INSERT INTO kingdoms
            (lordId, name, garrison, imgUrl)
            VALUES
            (@LordId, @Name, @Garrison, @ImgUrl)
            SELECT LAST_INSERT_ID()
            ";
            newKingdom.Id = _db.ExecuteScalar<int>(sql, newKingdom);
            return newKingdom;
        }

        public bool Update(Kingdom original)
        {
            string sql = @"
            UPDATE kingdoms
            SET
                lordId = @LordId
                name = @Name,
                garrison = @Garrison,
                imgUrl = @ImgUrl
            ";
            int affectedRows = _db.Execute(sql, original);
            return affectedRows == 1;
        }

        public bool Delete(int id)
        {
            string sql = "DELETE FROM kingdoms WHERE id = @id LIMIT 1";
            int affectedRows = _db.Execute(sql, new { id });
            return affectedRows == 1;
        }

    }
}