using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.IServices
{
    public interface IMessageBusService
    {
        //representa a publicação da mensagem
        // queue = fila
        // message ela tem que ser convertido em bytes pq é o que as filas armazenam
        void Publish(string queue, byte[] message); 
    }
}
