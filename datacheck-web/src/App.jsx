import { useEffect, useState } from 'react'

const barvy = {
  Chyba: '#c0392b',
  Varovani: '#d68910',
  Informace: '#2e86c1',
}

function SubjektyTabulka({ subjekty }) {
  return (
    <table border="1" cellPadding="6" style={{ borderCollapse: 'collapse' }}>
      <thead>
        <tr>
          <th>Id</th>
          <th>Typ</th>
          <th>Název</th>
          <th>IČO</th>
          <th>Město</th>
          <th>PSČ</th>
        </tr>
      </thead>
      <tbody>
        {subjekty.map((s) => (
          <tr key={s.id}>
            <td>{s.id}</td>
            <td>{s.typ}</td>
            <td>{s.nazev}</td>
            <td>{s.ico ?? '—'}</td>
            <td>{s.mesto ?? '—'}</td>
            <td>{s.psc ?? '—'}</td>
          </tr>
        ))}
      </tbody>
    </table>
  )
}

function NalezyTabulka({ nalezy, subjekty }) {
  const nazevSubjektu = (id) =>
    subjekty.find((s) => s.id === id)?.nazev || `(subjekt ${id})`

  return (
    <table border="1" cellPadding="6" style={{ borderCollapse: 'collapse' }}>
      <thead>
        <tr>
          <th>Závažnost</th>
          <th>Subjekt</th>
          <th>Pravidlo</th>
          <th>Popis</th>
          <th>Zjištěno</th>
        </tr>
      </thead>
      <tbody>
        {nalezy.map((n, index) => (
          <tr key={index}>
            <td style={{ color: barvy[n.zavaznost], fontWeight: 'bold' }}>
              {n.zavaznost}
            </td>
            <td>{nazevSubjektu(n.subjektId)}</td>
            <td>{n.kodPravidla}</td>
            <td>{n.popis}</td>
            <td>{new Date(n.zjisteno).toLocaleString('cs-CZ')}</td>
          </tr>
        ))}
      </tbody>
    </table>
  )
}

function App() {
  const [subjekty, setSubjekty] = useState([])
  const [nalezy, setNalezy] = useState([])
  const [nacitani, setNacitani] = useState(true)
  const [chyba, setChyba] = useState(null)

  useEffect(() => {
    const nacti = (url) =>
      fetch(url).then((odpoved) => {
        if (!odpoved.ok) throw new Error(`${url} vrátil ${odpoved.status}`)
        return odpoved.json()
      })

    Promise.all([nacti('/api/subjekty'), nacti('/api/nalezy')])
      .then(([s, n]) => {
        setSubjekty(s)
        setNalezy(n)
      })
      .catch((e) => setChyba(e.message))
      .finally(() => setNacitani(false))
  }, [])

  if (nacitani) return <p>Načítám…</p>
  if (chyba) return <p>Chyba: {chyba}</p>

  return (
    <div style={{ padding: 24 }}>
      <h1>DataCheck</h1>

      <h2>Nálezy ({nalezy.length})</h2>
      <NalezyTabulka nalezy={nalezy} subjekty={subjekty} />

      <h2>Subjekty ({subjekty.length})</h2>
      <SubjektyTabulka subjekty={subjekty} />
    </div>
  )
}

export default App