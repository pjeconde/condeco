using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondecoEntidades
{
    [Serializable]
    public class Comentario
    {
        private int id;
        private int idReplica;
        private string nombreEntidad;
        private int idEntidad;
        private string nombreUsuario;
        private string idUsuario;
        private DateTime fecha;
        private string url;
        private string contenido;
        private string estado;
        private int manoOk;
        private int manoNoOk;
        private int abusoContenido;

        public Comentario()
        {
            Default();
        }

        private void Default()
        {
            id = 0;
            idReplica = 0;
            nombreEntidad = String.Empty;
            idEntidad = 0;
            fecha = new DateTime(2000, 1, 1);
            idUsuario = String.Empty;
            nombreUsuario = String.Empty;
            url = String.Empty;
            contenido = String.Empty;
            estado = String.Empty;
            manoOk = 0;
            manoNoOk = 0;
            abusoContenido = 0;
        }

        public int Id
        { get { return id; } set { id = value; } }

        public int IdReplica
        { get { return idReplica; } set { idReplica = value; } }

        public string NombreEntidad
        { get { return nombreEntidad; } set { nombreEntidad = value; } }

        public int IdEntidad
        { get { return idEntidad; } set { idEntidad = value; } }

        public string NombreUsuario
        { get { return nombreUsuario; } set { nombreUsuario = value; } }

        public string IdUsuario
        { get { return idUsuario; } set { idUsuario = value; } }

        public DateTime Fecha
        { get { return fecha; } set { fecha = value; } }

        public string Url
        { get { return url; } set { url = value; } }

        public string Contenido
        { get { return contenido; } set { contenido = value; } }

        public string Estado
        { get { return estado; } set { estado = value; } }

        public int ManoOk
        { get { return manoOk; } set { manoOk = value; } }

        public int ManoNoOk
        { get { return manoNoOk; } set { manoNoOk = value; } }

        public int AbusoContenido
        { get { return abusoContenido; } set { abusoContenido = value; } }

    }
}
