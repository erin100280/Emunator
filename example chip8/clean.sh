echo "Project Cleaner"
echo "Use it before commit on SVN"
echo "Start Cleaning..."

rm -Rf SharpChip8/obj
rm -Rf SharpChip8/bin

rm -Rf SharpChip8-Metro/obj
rm -Rf SharpChip8-Metro/bin

rm -Rf SharpChip8-OTK/obj
rm -Rf SharpChip8-OTK/bin

rm -Rf SharpChip8-wf/obj
rm -Rf SharpChip8-wf/bin

echo "Cleaning done"