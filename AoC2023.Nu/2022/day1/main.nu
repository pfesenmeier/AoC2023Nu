def main [file: path] {
  (
    open $file
    | lines
    | split list ""
    | each { each { into int } | math sum }
    | math max
  )
}