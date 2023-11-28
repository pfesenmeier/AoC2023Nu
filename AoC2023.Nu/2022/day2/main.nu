let you_win = ["A Y" "C X" "B Z"]
let you_te = ["A X" "B Y" "C Z"]
let choice_scope = { X: 1, Y: 2, Z: 3 }

def main [file: path] {
    (
        open $file
        | lines
        | reduce --fold 0 {|it, acc|
            let their_choice = $it | split chars | first;
            let your_choice = $it | split chars | last; 

            let your_choice_score = ($choice_scope | get $your_choice);
            if ($you_win | any {|| $in == $it } ) {
                $acc + 6 + $your_choice_score
            } else if ($you_te | any {|| $in == $it } ) {
                $acc + 3 + $your_choice_score
            } else {
                $acc + $your_choice_score
            }
          }
    )
}