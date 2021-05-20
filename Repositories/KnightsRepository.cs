using System.Collections.Generic;
using System.Data;
using cs_knights_tale.Models;
using Dapper;

namespace cs_knights_tale.Repositories
{
    public class KnightsRepository : IRepository<Knight>
    {
        private readonly IDbConnection _db;

        public KnightsRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<Knight> GetAll()
        {
            string sql = "SELECT * FROM knights";
            return _db.Query<Knight>(sql);
        }

        public Knight GetById(int id)
        {
            // Dapper uses '@' to indicate a variable that can be safelt injected in the Query arguments
            string sql = "SELECT * FROM knights WHERE id = @id";
            // Query first or default returns a single item or 'null'
            return _db.QueryFirstOrDefault<Knight>(sql, new { id });
        }

        public Knight Create(Knight newKnight)
        {
            string sql = @"
            INSERT INTO knights
            (kingdomId, name, age, imgUrl)
            VALUES
            (@KingdomId, @Name, @Age, @ImgUrl)
            SELECT LAST_INSERT_ID()
            ";
            newKnight.Id = _db.ExecuteScalar<int>(sql, newKnight);
            return newKnight;
        }

        public bool Update(Knight original)
        {
            string sql = @"
            UPDATE knights
            SET
                kingdomId = @KingdomId,
                name = @Name,
                age = @Age
                imgUrl = @ImgUrl
            ";
            int affectedRows = _db.Execute(sql, original);
            return affectedRows == 1;
        }

        public bool Delete(int id)
        {
            string sql = "DELETE FROM knights WHERE id = @id LIMIT 1";
            int affectedRows = _db.Execute(sql, new { id });
            return affectedRows == 1;
        }
    }
}