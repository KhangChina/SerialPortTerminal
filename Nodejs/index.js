const { SerialPortStream } = require('@serialport/stream')

const serialport = new SerialPortStream({ path: 'com6', baudRate: 9600 })
// serialport.on('open', () => {
//     serialport.port.emitData('data')
//   })
  serialport.on('readable', function () {
    console.log('Data:', serialport.read())
  })
  serialport.on('data', function (data) {
    console.log('Data:', data)
  })
  const lineStream = port.pipe(new Readline())
  console.log(lineStream)