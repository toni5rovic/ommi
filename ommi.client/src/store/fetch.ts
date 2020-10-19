const baseUrl = process.env.VUE_APP_API_BASEURL

export function GET (url: string, authorize = true, token: string) {
  const requestHeaders: HeadersInit = new Headers()

  const requestOptions: RequestInit = {
    method: 'GET'
  }

  if (authorize) {
    requestHeaders.set('Authorization', 'Bearer ' + token)
  }

  requestOptions.headers = requestHeaders

  // do the fetch
  return fetch(baseUrl + url, requestOptions)
    .then(response => {
      if (response.ok) {
        return response
      } else {
        throw response
      }
    })
}

export function POST (url: string, body: string | object | undefined = undefined, authorize = true, token: string) {
  const requestHeaders: HeadersInit = new Headers()

  const requestOptions: RequestInit = {
    method: 'POST'
  }

  if (body) {
    let bodyString = ''
    if (typeof body !== 'string') {
      bodyString = JSON.stringify(body)
    } else {
      bodyString = body
    }

    requestOptions.body = bodyString
    requestHeaders.set('Content-Type', 'application/json')
  }

  if (authorize) {
    requestHeaders.set('Authorization', 'Bearer ' + token)
  }

  requestOptions.headers = requestHeaders

  // do the fetch
  return fetch(baseUrl + url, requestOptions)
    .then(response => {
      if (response.ok) {
        return response
      } else {
        throw response
      }
    })
}
