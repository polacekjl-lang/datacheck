import { useEffect, useState } from 'react'

function App() {
  const [subjekty, setSubjekty] = useState([])
  const [nacitani, setNacitani] = useState(true)
  const [chyba, setChyba] = useState(null)

  useEffect(() => {
    fetch('/api/subjekty')
      .then((odpoved) => {
        if (!odpoved.ok) throw new Error(`Server vrátil ${odpoved.status}`)
        return odpoved.json()
      })
      .then((data) => setSubjekty(data))
      .catch((e) => setChyba(e.message))
      .finally(() => setNacitani(false))
  }, [])

  if (nacitani) return <p>Načítám…</p>
  if (chyba) return <p>Chyba: {chyba}</p>

  return (
    <div style={{ padding: 24 }}>
      <h1>DataCheck</h1>
      <p>Subjektů: {subjekty.length}</p>

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
    </div>
  )
}

export default App